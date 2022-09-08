﻿using etickets.Models;
using Microsoft.EntityFrameworkCore;

namespace etickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(o => new
            {
              o.ActorId,
              o.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(m => m.Actors_Movies)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(m => m.Actors_Movies)
                .HasForeignKey(m => m.ActorId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
