using Shop.Domain.Comands.Requests;
using Shop.Domain.Comands.Response;
using Shop.Models;
using System;

namespace Shop.Domain.Mappers
{
    public static class CustumerMapper
    {
        public static CustumerResponse Map(this Custumer custumer)
        {
            return new CustumerResponse()
            {
                Data = custumer.Data,
                Email = custumer.Email,
                Name = custumer.Name
            };
        }

        public static Custumer Map(this CustumerRequest custumer)
        {
            return new Custumer()
            {
                Data = DateTime.Now,
                Email = custumer.Email,
                Name = custumer.Name,
                Password = custumer.Password,
                Role = custumer.Role,
                Username = custumer.Username
            };
        }
    }
}
