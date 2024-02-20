using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Comands.Handllers;
using Shop.Domain.Comands.Requests;
using Shop.Domain.Comands.Response;
using Shop.Models;
using Shop.Repositories;

namespace Shop.Controllers
{
    [ApiController]
    [Route("/Custumer")]
    public class CustumerContoller : ControllerBase
    {

        private readonly GetCustumerListHandler _GetCustumerListHandler;

        public CustumerContoller(GetCustumerListHandler getCustumerListHandler)
        {
            _GetCustumerListHandler = getCustumerListHandler;
        }

        [HttpPost]
        [Route("/register-custumer")]
        public Task<CustumerResponse> CreatCustumer(
            [FromServices]IMediator mediator,
            [FromBody]CustumerRequest custumerRequest){
            return mediator.Send(custumerRequest);
        }

        [HttpGet]
        [Route("/Lista")]
        public Task<List<Custumer>> GetCustumerList(
            [FromServices] IMediator mediator
            )
        {
            return _GetCustumerListHandler.GetCustumersList();
        }
    }   
}