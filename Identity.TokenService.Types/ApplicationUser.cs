using System;
using Microsoft.AspNetCore.Identity;

namespace Identity.TokenService.Types
{
    public class ApplicationUser :  IdentityUser<int>
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string name) :base(name)
        {
        
        }
        public Guid Tenant { get; set; }           // The EDS Tenant.
        public Guid SubjectId { get; set; }         // The EDS User ID.

    }
}
