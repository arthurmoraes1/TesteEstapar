using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteEstapar.Business.Models;

namespace TesteEstapar.Data.Mappings
{
    public class ManobristaMapping : IEntityTypeConfiguration<Manobrista>
    {
        public void Configure(EntityTypeBuilder<Manobrista> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Cpf)
                    .IsRequired()
                    .HasColumnType("varchar(11)");

            builder.HasMany(r => r.ResponsavelManobras)
                .WithOne(m => m.Manobrista)
                .HasForeignKey(p => p.ManobristaId);


            builder.ToTable("Manobristas");

        }
    }
}
