using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.Web.Data
{
	public class AppDbContext : IdentityDbContext
	{
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }
    }
}
