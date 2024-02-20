using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Shop.Repositories
{
    public class CustumerRepository : ICustumerRepository
    {
        private readonly DataContext _dataContext;
        
        public CustumerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<List<Custumer>> buscarCustumers()
        {
           return _dataContext.Custumers.ToListAsync();
        }

        public Task<Custumer> getCustumerByEmail(string email)
        {
            return _dataContext.Custumers
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public Task<Custumer> getCustumerByname(string name)
        {
            return _dataContext.Custumers
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public void Save(Custumer custumer)
        {
            _dataContext.Custumers.Add(custumer);
        }
    }
}