using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Models
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public ApplicationRoleClaim() 
        {

        }
    }
}