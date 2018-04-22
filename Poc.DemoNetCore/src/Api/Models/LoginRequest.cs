 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class LoginRequest
    {
        public string Login { get; set; } = "admin";
        public string Senha { get; set; } = "admin";
    }
}
