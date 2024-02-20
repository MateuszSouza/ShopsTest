using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Comands.Requests;
using Shop.Domain.Comands.Response;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shop.Controllers
{
    [ApiController]
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {

        [HttpPost("/criar-order")]
        public Task<CreateOrderResponse> CreatOrderRequest(
            [FromServices] IMediator mediator,
            OrderRequest orderRequest
            )
        {
                return mediator.Send(orderRequest);
        }

        [HttpGet("/get-orderList/{page}/{size}/{email}")]
        public Task<List<OrdersResponse>> GetCustumerOrders(
            [FromServices] IMediator mediator,
            int page,int size, string email
        )
        {
            var request = new GetOrderCustumerRequest(){
                CustumerEmail = email,
                Page = page,
                Size = size
            };
            return mediator.Send(request);
        }

    }
}
