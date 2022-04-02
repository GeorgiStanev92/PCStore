using Microsoft.EntityFrameworkCore;
using PCStore.Core.Contracts;
using PCStore.Core.Models;
using PCStore.Infrastrucure.Data;
using PCStore.Infrastrucure.Repositories;

namespace PCStore.Core.Services
{
    public class DisplayOrderService : IOrderService
    {
        private readonly IApplicatioDbRepository repo;

        public DisplayOrderService(IApplicatioDbRepository _repo)
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

            var displays = await repo.All<Display>()
                .Where(i => barcode.Contains(i.Barcode))
                .ToDictionaryAsync(c => c.Barcode, c => c.ItemsCount);

            foreach (var display in order.Computers)
            {
                if (!displays.ContainsKey(display.Barcode) ||
                    display.Count > displays[display.Barcode])
                {
                    throw new ArgumentException("Not enough quantity");
                }
            }
        }
    }
}
