using Core.Domain.BankaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class BankaConfiguration : IEntityTypeConfiguration<Banka>
    {
        public void Configure(EntityTypeBuilder<Banka> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
