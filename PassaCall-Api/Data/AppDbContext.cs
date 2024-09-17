using Microsoft.EntityFrameworkCore;
using PassaCall_Api.Models;

namespace PassaCall_Api.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<TeamModel> Team { get; set; }

    }
}
