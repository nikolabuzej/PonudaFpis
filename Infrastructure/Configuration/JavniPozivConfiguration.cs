using Core.Domain.JavniPozivAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
