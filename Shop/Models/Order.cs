using System;
using Shop.Domain.Enums;


namespace Shop.Models
{
    public class Order
    {

        public Guid Id { get; set; }
        public string Number { get; set; }
     
        public Guid CustumerId { get; set; }
     
        public Custumer Custumer { get; set; }

        public OrderEnum status { get; set; }

        public string Description { get; set; }

        public int Quantidade { get; set; }

    }
}