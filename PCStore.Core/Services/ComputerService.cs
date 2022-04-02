using Microsoft.EntityFrameworkCore;
using PCStore.Core.Contracts;
using PCStore.Core.Models;
using PCStore.Infrastrucure.Data;
using PCStore.Infrastrucure.Repositories;

namespace PCStore.Core.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IApplicatioDbRepository repo;

        public ComputerService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public IQueryable<Computer> GetAll()
        {
            return repo.All<Computer>();
        }

        public void Update(Computer computer)
        {
            repo.Update(computer);
        }

        public async void Add(Computer computer)
        {
           await repo.AddAsync(computer);
        }

        public void Delete(Computer computer)
        {
            repo?.Delete(computer);
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

        //    var computers = await repo.All<Computer>()
        //        .Where(i => barcode.Contains(i.Barcode))
        //        .ToDictionaryAsync(c => c.Barcode, c => c.ItemsCount);

        //    foreach (var computer in order.Computers)
        //    {
        //        if (!computers.ContainsKey(computer.Barcode) ||
        //            computer.Count > computers[computer.Barcode])
        //        {
        //            throw new ArgumentException("Not enough quantity");
        //        }
        //    }
        //}
    }
}
