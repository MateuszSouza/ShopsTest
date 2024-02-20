using Shop.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.Comands.Response;

namespace Shop.Domain.Comands.Requests
{
    public class OrderRequest : 
    IRequest<CreateOrderResponse>
    {
        public string name { get; set; }
        public string Description { get; set; }

        public int Quantidade { get; set; }

        public string CustumerEmail { get; set; }

    }
}
