using PCStore.Core.Contracts;
using PCStore.Infrastrucure.Data;
using PCStore.Infrastrucure.Repositories;

namespace PCStore.Core.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly IApplicatioDbRepository repo;

        public LaptopService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public IQueryable<Laptop> GetAll()
        {
            return repo.All<Laptop>();
        }

        public void Update(Laptop laptop)
        {
            repo.Update(laptop);
        }

        public async void Add(Laptop laptop)
        {
           repo.AddAsync(laptop);
        }

        public void Delete(Laptop laptop)
        {
            repo.Delete(laptop);
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

        //    var laptops = await repo.All<Laptop>()
        //        .Where(i => barcode.Contains(i.Barcode))
        //        .ToDictionaryAsync(c => c.Barcode, c => c.ItemsCount);

        //    foreach (var laptop in order.Computers)
        //    {
        //        if (!laptops.ContainsKey(laptop.Barcode) ||
        //            laptop.Count > laptops[laptop.Barcode])
        //        {
        //            throw new ArgumentException("Not enough quantity");
        //        }
        //    }
        //}
    }
}
