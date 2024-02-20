using MediatR;
using System.Collections.Generic;
using Shop.Domain.Comands.Response;

namespace Shop.Domain.Comands.Requests

{
    public class GetOrderCustumerRequest : 
    IRequest<List<OrdersResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string CustumerEmail { get; set; }
 
    }
}