using PCStore.Core.Contracts;
using PCStore.Infrastrucure.Data;
using PCStore.Infrastrucure.Repositories;

namespace PCStore.Core.Services
{
    public class DisplayService : IDisplayService
    {
        private readonly IApplicatioDbRepository repo;

        public DisplayService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public IQueryable<Display> GetAll()
        {
            return repo.All<Display>();
        }

        public void Update(Display display)
        {
            repo.Update(display);
        }

        public async void Add(Display display)
        {
          await repo.AddAsync(display);
        }

        public void Delete(Display display)
        {
            repo?.Delete(display);
        }

        //public async Task PlaceOrder(CustomerOrder order)
        //{
        //    var customerNumber = order.CustomerNumber.Trim();
        //    var customer = await repo.All<Contragent>()
        //        .FirstOrDefaultAsync(c => c.CustomerNumber == customerNumber);

        //    if (customer == null)
        //    {
        //        throw new ArgumentException("Customer doesn`t exist");
        //    }

        //    var barcode = order.Computers
        //        .Select(c => c.Barcode)
        //        .ToArray();

        //    var displays = await repo.All<Display>()
        //        .Where(i => barcode.Contains(i.Barcode))
        //        .ToDictionaryAsync(c => c.Barcode, c => c.ItemsCount);

        //    foreach (var display in order.Computers)
        //    {
        //        if (!displays.ContainsKey(display.Barcode) ||
        //            display.Count > displays[display.Barcode])
        //        {
        //            throw new ArgumentException("Not enough quantity");
        //        }
        //    }
        //}
    }
}
