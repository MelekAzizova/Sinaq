using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TempData.Models;

namespace TempData.Contexts
{
    public class TempDbContext:IdentityDbContext
    {
        public TempDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<Team> Teams { get; set; }
    }
}
