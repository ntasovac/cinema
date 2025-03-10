using Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    /*
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieScreening> MovieScreenings { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Reservation> Reservations { get; set; }*/

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(320); // fact
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Password).IsRequired().HasMaxLength(255);
            entity.Property(u => u.BirthDate).IsRequired().HasMaxLength(100);
            entity.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15); // fact
            entity.Property(u => u.Type).IsRequired();
        });
    }

}

