using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Data;
using Shop.Domain.Comands.Requests;
using Shop.Domain.Comands.Response;
using Shop.Models;
using Shop.Repositories;
using Shop.Domain.Mappers;

namespace Shop.Domain.Comands.Handlers
{
    public class CustumerHandler : 
    IRequestHandler<CustumerRequest,CustumerResponse>
    {
        private readonly ICustumerRepository _custumerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustumerHandler
            (ICustumerRepository custumerRepository,
            IUnitOfWork unitOfWork)
        {
            _custumerRepository = custumerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustumerResponse> Handle(CustumerRequest custumerRequest, 
        CancellationToken cancellationToken)
        {

            Custumer newCustumer = custumerRequest.Map();

            _custumerRepository.Save(newCustumer);
            _unitOfWork.Commit();

            newCustumer = await _custumerRepository
                .getCustumerByname(newCustumer.Name);


            var result = newCustumer.Map();

            return result;
        }
    }
}