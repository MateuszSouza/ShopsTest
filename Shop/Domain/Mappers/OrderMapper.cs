using Shop.Domain.Comands.Requests;
using Shop.Domain.Comands.Response;
using Shop.Domain.Enums;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Mappers
{
    public static class OrderMapper
    {
        public static Order Map(this OrderRequest orderRequest,
            Custumer custumer)
        {
            Random randNum = new Random();
            return new Order()
            {
                Custumer = custumer,
                CustumerId = custumer.Id,
                Number = randNum.Next().ToString(),
                Id = Guid.NewGuid(),
                Description = orderRequest.Description,
                Quantidade = orderRequest.Quantidade
            };
        }

        public static CreateOrderResponse Map(this Order order)
        {
            return new CreateOrderResponse()
            {
                 status = order.status
            };
        }

        public static OrdersResponse Maps(this Order order){
            return new OrdersResponse()
            {
                CustumerName = order.Custumer?.Name,
                Description = order.Description,
                Number = order.Number,
                Quantidade = order.Quantidade,
                status = order.status
            };
        }
    }
}
