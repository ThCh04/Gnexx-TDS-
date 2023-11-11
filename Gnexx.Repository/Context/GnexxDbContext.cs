using Gnexx.Data.Entities;
using Gnexx.Models.Entities;
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
        public GnexxDbContext(DbContextOptions<GnexxDbContext> options) : base(options)
        {

        }
        public DbSet<Users> User { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a uno entre User y Player
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Players)
                .WithOne(p => p.Users)
                .HasForeignKey<Player>(p => p.UserID)
                .OnDelete(DeleteBehavior.NoAction);
                

            // Relación uno a uno entre User y Coach
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Coaches)
                .WithOne(c => c.Users)
                .HasForeignKey<Coach>(c => c.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            // Relación uno a muchos entre Team y Player
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Teams)
                .HasForeignKey(p => p.TeamID)
                .OnDelete(DeleteBehavior.NoAction);


            // Relación uno a uno entre Team y Coach
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Coach)
                .WithOne(c => c.Teams)
                .HasForeignKey<Coach>(c => c.TeamID)
                .OnDelete(DeleteBehavior.NoAction);


            // Relaciones uno a muchos entre User y News, Comments y Responses
            modelBuilder.Entity<Users>()
                .HasMany(u => u.News)
                .WithOne(n => n.Users)
                .HasForeignKey(n => n.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Users>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Users>()
                .HasMany(u => u.Responses)
                .WithOne(r => r.Users)
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Comments>()
                .HasMany(u => u.Responses)
                .WithOne(r => r.Comments)
                .HasForeignKey(r => r.CommentsID)
                .OnDelete(DeleteBehavior.NoAction);


            // Otras configuraciones de relaciones si es necesario

            base.OnModelCreating(modelBuilder);
        }

    }
}
