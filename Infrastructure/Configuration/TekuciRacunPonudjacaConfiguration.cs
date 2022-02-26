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
    class TekuciRacunPonudjacaConfiguration : IEntityTypeConfiguration<TekuciRacunPonudjaca>
    {
        public void Configure(EntityTypeBuilder<TekuciRacunPonudjaca> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
