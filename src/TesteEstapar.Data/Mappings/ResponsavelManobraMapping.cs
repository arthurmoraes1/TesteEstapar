using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteEstapar.Business.Models;

namespace TesteEstapar.Data.Mappings
{
    public class ResponsavelManobraMapping : IEntityTypeConfiguration<ResponsavelManobra>
    {
        public void Configure(EntityTypeBuilder<ResponsavelManobra> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("ResponsaveisManobras");
        }
    }
}
