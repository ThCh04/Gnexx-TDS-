using Gnexx.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Gnexx.Data
{
    public class GnexxDbContext : DbContext
    {
        public GnexxDbContext(DbContextOptions<GnexxDbContext> options) : base(options)
        {

        }
        public DbSet<Users> User { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<User_type> User_Type { get; set; }

    }

}
