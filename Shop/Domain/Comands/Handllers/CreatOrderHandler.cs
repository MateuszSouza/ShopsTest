using MediatR;
using Shop.Data;
using Shop.Domain.Comands.Requests;
using Shop.Domain.Comands.Response;
using Shop.Domain.Enums;
using Shop.Domain.Mappers;
using Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Domain.Comands.Handllers
{

    public class CreatOrderHandler :
        IRequestHandler<OrderRequest, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRespository;
        private readonly ICustumerRepository _custumerRepository;
        private readonly IUnitOfWork _uow;

        public CreatOrderHandler(IOrderRepository orderRespository,
            ICustumerRepository custumerRepository,
            IUnitOfWork uow)
        {
            _orderRespository = orderRespository;
            _custumerRepository = custumerRepository;
            _uow = uow;
        }


        public async Task<CreateOrderResponse> Handle(OrderRequest request, CancellationToken cancellationToken)
        {
            var createdOrderResponse = new CreateOrderResponse();

            try
            {
                var custumer = await _custumerRepository
                    .getCustumerByEmail(request.CustumerEmail);
                var order = request.Map(custumer);
                order.status = OrderEnum.created;
                createdOrderResponse = order.Map();
                _orderRespository.Save(order);
            }
            catch (Exception)
            {
                createdOrderResponse.status = OrderEnum.NotCreated;
                return createdOrderResponse;
            }

            _uow.Commit();
            return createdOrderResponse;
        }
    }
}
