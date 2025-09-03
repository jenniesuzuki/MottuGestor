using Microsoft.EntityFrameworkCore;
using MottuGestor.Domain.Entities;

namespace MottuGestor.Infrastructure.Context;

public class MottuGestorContext : DbContext
{
    public MottuGestorContext(DbContextOptions<MottuGestorContext> options) : base(options) { }

    public DbSet<Patio> Patios => Set<Patio>();
    public DbSet<Moto> Motos  => Set<Moto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MottuGestorContext).Assembly);
    }
}