using Microsoft.EntityFrameworkCore;
using PCStore.Core.Contracts;
using PCStore.Core.Models;
using PCStore.Infrastrucure.Data;
using PCStore.Infrastrucure.Repositories;

namespace PCStore.Core.Services
{
    public class ComputerOrderService : IOrderService
    {
        private readonly IApplicatioDbRepository repo;

        public ComputerOrderService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task PlaceOrder(CustomerOrder order)
        {
            var customerNumber = order.CustomerNumber.Trim();
            var customer = await repo.All<Contragent>()
                .FirstOrDefaultAsync(c => c.CustomerNumber == customerNumber);

            if (customer == null)
            {
                throw new ArgumentException("Customer doesn`t exist");
            }

            var computerId = order.Computers
                .Select(c => c.Barcode)
                .ToArray();

            var computers = await repo.All<Computer>()
                .Where(i => computerId.Contains(i.Barcode))
                .ToDictionaryAsync(c => c.Barcode, c => c.ItemsCount);

            foreach (var computer in order.Computers)
            {
                if (!computers.ContainsKey(computer.Barcode) ||
                    computer.Count > computers[computer.Barcode])
                {
                    throw new ArgumentException("Not enough quantity");
                }
            }
        }
    }
}
