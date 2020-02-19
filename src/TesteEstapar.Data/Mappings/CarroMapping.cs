using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteEstapar.Business.Models;

namespace TesteEstapar.Data.Mappings
{
    public class CarroMapping : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Marca)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Modelo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Placa)
                .IsRequired()
                .HasColumnType("varchar(7)");

            builder.HasMany(r => r.ResponsavelManobras)
                .WithOne(c => c.Carro)
                .HasForeignKey(p => p.CarroId);

            builder.ToTable("Carros");
        }
    }
}
