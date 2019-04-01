using Microsoft.AspNetCore.Identity;

namespace Identity.TokenService.Types
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() { }
        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }
    }
}
