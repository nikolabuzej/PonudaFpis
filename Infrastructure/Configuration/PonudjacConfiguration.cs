using Core.Domain.PonudjacAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
