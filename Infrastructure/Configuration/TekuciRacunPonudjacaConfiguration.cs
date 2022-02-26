using Core.Domain.PonudaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    class TekuciRacunPonudjacaConfiguration : IEntityTypeConfiguration<TekuciRacunPonudjaca>
    {
        public void Configure(EntityTypeBuilder<TekuciRacunPonudjaca> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
