using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions ops) : base(ops) 
        {
        
        }

        public DbSet<Post> Posts { get; set; }
    }
}
