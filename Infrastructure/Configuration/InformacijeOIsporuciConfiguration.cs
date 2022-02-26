using Core.Domain.InformacijeOIsporuciAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    class InformacijeOIsporuciConfiguration : IEntityTypeConfiguration<InformacijeOIsporuci>
    {
        public void Configure(EntityTypeBuilder<InformacijeOIsporuci> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
