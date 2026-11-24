using CarRental.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Auto> Autos { get; set; }
    public DbSet<Alquiler> Alquileres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>()
            .Property(a => a.Precio)
            .HasPrecision(6, 2);

        base.OnModelCreating(modelBuilder);
    }
}