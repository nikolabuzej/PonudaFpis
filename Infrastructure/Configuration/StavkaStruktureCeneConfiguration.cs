using Core.Domain.PonudaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    class StavkaStruktureCeneConfiguration : IEntityTypeConfiguration<StavkaStruktureCene>
    {
        public void Configure(EntityTypeBuilder<StavkaStruktureCene> builder)
        {
            builder.HasKey(x => x.Id);
            
        }
    }
}
