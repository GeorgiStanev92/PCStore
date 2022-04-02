using PCStore.Infrastrucure.Data;

namespace PCStore.Core.Contracts
{
    public interface IDisplayService
    {
        IQueryable<Display> GetAll();
        void Add(Display display);
        void Delete(Display display);
        void Update(Display display);
    }
}
