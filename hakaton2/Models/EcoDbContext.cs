using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace hakaton2.Models
{
    public class EcoDbContext : IdentityDbContext<User>
    {
        
    }
}
