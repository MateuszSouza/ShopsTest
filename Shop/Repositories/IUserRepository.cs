using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Repositories
{
    public interface IUserRepository
    {

        public Usuario GetUserByEmail(string email);
        public Usuario GetUserByUserNameAndPassword(string username, string password);
        public void SaveUser(Usuario user);
    }
}
