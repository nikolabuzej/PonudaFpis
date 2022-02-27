using Core.Domain.PonudaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    class StavkaStruktureCeneConfiguration : IEntityTypeConfiguration<StavkaStruktureCene>
    {
        public void Configure(EntityTypeBuilder<StavkaStruktureCene> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            
        }
    }
}
