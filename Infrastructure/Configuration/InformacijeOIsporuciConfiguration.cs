using Core.Domain.InformacijeOIsporuciAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
