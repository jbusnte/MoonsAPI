using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MoonsAPI.Models;

namespace MoonsAPI.Models
{
    public class MoonsAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MoonsAPIDBContext(DbContextOptions<MoonsAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("MoonsDataService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Moon> Moons { get; set; } = null!;
        public DbSet<Parent> Parents { get; set; } = null!;
    }
}
