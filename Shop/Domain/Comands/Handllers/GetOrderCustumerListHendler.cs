using MediatR;
using Shop.Domain.Comands.Requests;
using Shop.Domain.Comands.Response;
using Shop.Domain.Mappers;
using Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Domain.Comands.Handllers
{
    public class GetOrderCustumerListHendler :
        IRequestHandler<GetOrderCustumerRequest, List<OrdersResponse>>

    {
        private readonly IOrderRepository _orderRespository;

        public GetOrderCustumerListHendler(IOrderRepository orderRespository)
        {
            _orderRespository = orderRespository;
        }


        public Task<List<OrdersResponse>> Handle(GetOrderCustumerRequest request, CancellationToken cancellationToken)
        {
            var list = _orderRespository
                .GetListOrder(request.CustumerEmail, request.Page, request.Size);
            List<OrdersResponse> response = new();
            foreach (var order in list)
            {
                response.Add(order.Maps());
            }

            return Task.FromResult(response);
        }
    }
}
