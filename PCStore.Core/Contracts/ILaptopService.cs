using PCStore.Infrastrucure.Data;

namespace PCStore.Core.Contracts
{
    public interface ILaptopService
    {
        IQueryable<Laptop> GetAll();
        void Add(Laptop laptop);
        void Delete(Laptop laptop);
        void Update(Laptop laptop);
    }
}
