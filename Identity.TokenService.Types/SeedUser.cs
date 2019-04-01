using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Identity.TokenService.Types
{
    public class SeedUser : ApplicationUser
    {
        public string Password { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
