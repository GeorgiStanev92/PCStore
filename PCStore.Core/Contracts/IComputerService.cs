using PCStore.Infrastrucure.Data;

namespace PCStore.Core.Contracts
{
    public interface IComputerService
    {
        IQueryable<Computer> GetAll();
        void Add(Computer computer);
        void Delete(Computer computer);
        void Update(Computer computer);
    }
}
