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

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Hall> Halls { get; set; }

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
            entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
            entity.Property(u => u.BirthDate).IsRequired();
            entity.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15); // fact
            entity.Property(u => u.Type).IsRequired();
            entity.Property(u => u.RefreshToken);
            entity.Property(u => u.RefreshTokenExpiryTime);
        });

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(a => a.LastName).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Name).IsRequired().HasMaxLength(100);
            entity.Property(m => m.Description).IsRequired().HasMaxLength(255);
            entity.Property(m => m.Director).IsRequired().HasMaxLength(100);
            entity.Property(m => m.Duration).IsRequired();
            entity.Property(m => m.Genre).IsRequired().HasMaxLength(20);
            entity.Property(m => m.ReleaseDate).IsRequired();
            entity.Property(m => m.PosterImageUrl).IsRequired().HasMaxLength(255);
            entity.HasMany(m => m.Actors).WithOne().HasForeignKey(a => a.Id).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(h => h.Number);
            entity.Property(h => h.Name).IsRequired().HasMaxLength(100);
            entity.Property(h => h.TotalSeats).IsRequired();
            entity.HasMany(h => h.FreeSeats).WithOne().HasForeignKey(s => s.HallId);
            entity.HasMany(h => h.ReservedSeats).WithOne().HasForeignKey(s => s.HallId);
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(s => new {s.Number, s.Row, s.HallId});
            entity.Property(s => s.Type).IsRequired();
        });
    }

}

