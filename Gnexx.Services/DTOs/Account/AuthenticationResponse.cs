﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.DTOs.Account 
{ 
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName{ get; set; }
        public List<string> Roles { get; set; }
        public bool Verified { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
