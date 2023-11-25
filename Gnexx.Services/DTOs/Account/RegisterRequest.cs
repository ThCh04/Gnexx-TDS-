using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.DTOs.Account
{
    public class RegisterRequest
    {
        
        public string Email { get; set; }
        public string UserName{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Rol { get; set; }
        public long Phone { get; set; }
    }
}
