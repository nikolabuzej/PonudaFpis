using Core.Domain.JavniPozivAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal class JavniPozivConfiguration : IEntityTypeConfiguration<JavniPoziv>
    {
        public void Configure(EntityTypeBuilder<JavniPoziv> builder)
        {
            builder.HasKey(x=> x.Id);
        }
    }
}
