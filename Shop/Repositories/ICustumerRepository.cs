using Shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Repositories
{
    public interface ICustumerRepository
    {
        void Save(Custumer custumer);

        Task<List<Custumer>> buscarCustumers();

        public Task<Custumer> getCustumerByname(string name);

        public Task<Custumer> getCustumerByEmail(string email);
    } 

}