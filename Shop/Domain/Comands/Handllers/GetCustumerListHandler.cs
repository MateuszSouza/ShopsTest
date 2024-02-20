using Shop.Models;
using Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Comands.Handllers
{
    public class GetCustumerListHandler
    {
        private readonly ICustumerRepository _custumerRepository;

        public GetCustumerListHandler(ICustumerRepository custumerRepository)
        {
            _custumerRepository = custumerRepository;
        }

        public  Task<List<Custumer>> GetCustumersList()
        {
            return _custumerRepository.buscarCustumers();
        }
    }
}
