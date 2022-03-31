using Microsoft.EntityFrameworkCore;
using PCStore.Core.Contracts;
using PCStore.Core.Models;
using PCStore.Infrastrucure.Data;
using PCStore.Infrastrucure.Repositories;

namespace PCStore.Core.Services
{
    public class LaptopOrderService : IOrderService
    {
        private readonly IApplicatioDbRepository repo;

        public LaptopOrderService(IApplicatioDbRepository _repo)
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

            var barcode = order.Computers
                .Select(c => c.Barcode)
                .ToArray();

            var laptops = await repo.All<Computer>()
                .Where(i => barcode.Contains(i.Barcode))
                .ToDictionaryAsync(c => c.Barcode, c => c.ItemsCount);

            foreach (var computer in order.Computers)
            {
                if (!laptops.ContainsKey(computer.Barcode) ||
                    computer.Count > laptops[computer.Barcode])
                {
                    throw new ArgumentException("Not enough quantity");
                }
            }
        }
    }
}
