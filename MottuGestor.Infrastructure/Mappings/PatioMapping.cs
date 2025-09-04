using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottuGestor.Domain.Entities;

namespace MottuGestor.Infrastructure.Mappings;

public class PatioMapping : IEntityTypeConfiguration<Patio>
{
    public void Configure(EntityTypeBuilder<Patio> b)
    {
        b.HasKey(x => x.PatioId);

        b.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(120);

        b.HasMany(p => p.Motos)
            .WithOne(m => m.Patio)
            .HasForeignKey(m => m.PatioId)
            .OnDelete(DeleteBehavior.Cascade);

        var nav = b.Metadata.FindNavigation(nameof(Patio.Motos));
        nav?.SetField("_motos");
        nav?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}