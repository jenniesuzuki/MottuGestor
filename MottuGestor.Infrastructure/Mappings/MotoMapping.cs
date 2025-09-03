using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottuGestor.Domain.Entities;
using MottuGestor.Domain.ValueObjects;

namespace MottuGestor.Infrastructure.Mappings;

public class MotoMapping : IEntityTypeConfiguration<Moto>
{
    public void Configure(EntityTypeBuilder<Moto> b)
    {
        b.HasKey(x => x.MotoId);

        b.Property(x => x.Placa)
            .HasConversion(p => p.Value, v => new Placa(v))
            .HasColumnName("Placa")
            .HasMaxLength(10)
            .IsRequired();

        b.Property(x => x.RfidTag)
            .HasConversion(t => t.Value, v => new RfidTag(v))
            .HasColumnName("RfidTag")
            .HasMaxLength(32)
            .IsRequired();

        b.Property(x => x.Modelo).IsRequired().HasMaxLength(80);
        b.Property(x => x.Marca).IsRequired().HasMaxLength(80);
        b.Property(x => x.Ano).IsRequired();
        b.Property(x => x.DataCadastro).IsRequired();
        b.Property(x => x.Problema).HasMaxLength(500);
        b.Property(x => x.Localizacao).HasMaxLength(120);
    }
}