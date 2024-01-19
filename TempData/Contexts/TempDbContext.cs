using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TempData.Models;

namespace TempData.Contexts
{
    public class TempDbContext:IdentityDbContext
    {
        public TempDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<SosialMedia> SosialMedias { get; set; }
        public DbSet<MediaTeam> MediaTeams { get; set; }

       

    }
}
