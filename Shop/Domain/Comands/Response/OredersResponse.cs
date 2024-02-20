using Shop.Domain.Enums;
namespace Shop.Domain.Comands.Response

{
    public class OrdersResponse
    {
        public string Number { get; set; }
     
        public string CustumerName { get; set; }

        public OrderEnum status { get; set; }

        public string Description { get; set; }

        public int Quantidade { get; set; }
    }
}