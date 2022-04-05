using PCStore.Infrastrucure.Data;

namespace PCStore.Core.Contracts
{
    public interface IUsersService
    {
        IQueryable<User> GetAll();
        void Delete(User user);
        void Update(User user);
    }
}
