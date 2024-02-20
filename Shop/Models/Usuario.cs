using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Username { set; get; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
