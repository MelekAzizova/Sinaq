using Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Context
{
    public class TempDbContext:IdentityDbContext

    {
        public TempDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<News> News { get; set; }
    }
}
