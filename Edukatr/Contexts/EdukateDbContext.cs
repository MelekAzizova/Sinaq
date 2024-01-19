using Edukatr.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Edukatr.Contexts
{
    public class EdukateDbContext:IdentityDbContext
    {
        public EdukateDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
