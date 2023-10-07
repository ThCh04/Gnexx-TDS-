using Gnexx.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gnexx.Data
{
    public class GnexxDbContext : DbContext
    {
        public GnexxDbContext(DbContextOptions<GnexxDbContext> options) : base(options) 
        {

        }
        public DbSet<tb_user> User { get; set; }
        public DbSet<tb_news> News { get; set; }
    }

}
