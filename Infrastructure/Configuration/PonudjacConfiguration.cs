using Core.Domain.PonudjacAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    class PonudjacConfiguration : IEntityTypeConfiguration<Ponudjac>
    {
        public void Configure(EntityTypeBuilder<Ponudjac> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
