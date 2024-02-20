using Shop.Data;
using Shop.Models;
using System.Linq;

namespace Shop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Usuario GetUserByEmail(string email)
        {
           return _dataContext.Users
                .Where( u => u.Email == email)
                .FirstOrDefault();
        }

        public Usuario GetUserByUserNameAndPassword(string username,string password)
        {
            return _dataContext.Users
                 .Where(u => u.Username == username && u.Password == password)
                 .FirstOrDefault();
        }

        public void SaveUser(Usuario user)
        {
            _dataContext.Add(user);

        }
    }
}
