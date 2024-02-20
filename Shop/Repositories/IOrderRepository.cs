using Shop.Models;
using System.Collections.Generic;

namespace Shop.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
        List<Order> GetListOrder(string CustumerEmail,int page,int size);

        Order GetOrderByCustumerEmail(string email);
    } 
}