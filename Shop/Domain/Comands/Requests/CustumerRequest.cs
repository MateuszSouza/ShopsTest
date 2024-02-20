using MediatR;
using Shop.Domain.Comands.Response;
using Shop.Requests;

namespace Shop.Domain.Comands.Requests
{
    public class CustumerRequest :  IRequest<CustumerResponse>
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}