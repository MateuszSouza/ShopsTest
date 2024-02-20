using MediatR;
using Shop.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Requests
{
    public class LoginRequest 
        : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
