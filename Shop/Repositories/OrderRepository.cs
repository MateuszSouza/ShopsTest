using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System.Collections.Generic;
using System.Linq;


namespace Shop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Save(Order order)
        {
            _dataContext.Orders.Add(order);
            
        }

        public List<Order> GetListOrder(string CustumerEmail,int page,int size){
           return _dataContext.Orders
                .Where(x => x.Custumer.Email == CustumerEmail)
                .Include(x => x.Custumer)
                .ToList();
         }

        public Order GetOrderByCustumerEmail(string email)
        {
            return _dataContext.Orders
                .Where(x => x.Custumer.Email == email)
                .Include(x => x.Custumer)
                .FirstOrDefault();
        }
    }
}