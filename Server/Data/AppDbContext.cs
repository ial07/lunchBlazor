
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

        /// <Master>
        public DbSet<Departemen> Departemen { get; set; }
        public DbSet<Divisi> Divisi { get; set; }
        public DbSet<Golongan> Golongan { get; set; }
        public DbSet<JenisMpp> JenisMpp { get; set; }
        public DbSet<JenisPermintaan> JenisPermintaan { get; set; }
        public DbSet<Lokasi> Lokasi { get; set; }
        public DbSet<Posisi> Posisi { get; set; }
        public DbSet<SumberPemenuhan> SumberPemenuhan { get; set; }
        public DbSet<Status> Status { get; set; }

        public DbSet<Pendidikan> Pendidikan { get; set; }
        public DbSet<JurusanPendidikan> JurusanPendidikan { get; set; }

        /// <Main>
        public DbSet<MppForm> MppForm { get; set; }
        public DbSet<MppChildForm> MppChildForm { get; set; }
        public DbSet<HistoryMpp> HistoryMpp { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MppForm>()
                .HasMany(u => u.MppChildForm)
                .WithOne(r => r.MppForm)
                .HasForeignKey(u => u.MppFormId);

        }
    }
}

