using Microsoft.EntityFrameworkCore;

namespace RazorPages.Data
{
    public class RazorPagesDbContext : DbContext 
    {
        public RazorPagesDbContext(DbContextOptions<RazorPagesDbContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Student> Students {get; set;}
    }
}