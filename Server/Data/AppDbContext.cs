
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace lunchBlazor.Server.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
              .UseSqlServer(_configuration.GetConnectionString("defaultConn"));

        }

        public DbSet<Banner> Banner { get; set; }
    }
}

