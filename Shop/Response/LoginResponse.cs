using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Response
{
    public class LoginResponse
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }
    }
}
