using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Comands.Response
{
    public class CreateOrderResponse
    {
        public OrderEnum status { get; set; }
    }
}
