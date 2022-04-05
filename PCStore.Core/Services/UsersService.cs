using PCStore.Core.Contracts;
using PCStore.Infrastrucure.Data;
using PCStore.Infrastrucure.Repositories;

namespace PCStore.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IApplicatioDbRepository repo;

        public UsersService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public IQueryable<User> GetAll()
        {
            return repo.All<User>();
        }

        public void Update(User user)
        {
            repo.Update(user);
        }

        public void Delete(User user)
        {
            this.repo.Delete(user);
        }
    }
}
