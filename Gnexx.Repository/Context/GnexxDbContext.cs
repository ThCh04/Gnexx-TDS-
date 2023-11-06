using Gnexx.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Repository.Context
{
    public class GnexxDbContext : DbContext
    {
        public GnexxDbContext(DbContextOptions<GnexxDbContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a uno entre User y Player
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Player)
                .WithOne(p => p.User)
                .HasForeignKey<Player>(p => p.UserId);

            // Relación uno a uno entre User y Coach
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Coach)
                .WithOne(c => c.User)
                .HasForeignKey<Coach>(c => c.UserId);

            // Relación uno a muchos entre Team y Player
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);

            // Relación uno a uno entre Team y Coach
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Coach)
                .WithOne(c => c.Team)
                .HasForeignKey<Coach>(c => c.TeamId);

            // Relaciones uno a muchos entre User y News, Comments y Responses
            modelBuilder.Entity<Users>()
                .HasMany(u => u.News)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(u => u.Response)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            // Otras configuraciones de relaciones si es necesario

            base.OnModelCreating(modelBuilder);
        }
    }
}