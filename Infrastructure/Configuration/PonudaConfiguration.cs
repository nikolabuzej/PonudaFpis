using Core.Domain.JavniPozivAggregate;
using Core.Domain.PonudaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class PonudaConfiguration : IEntityTypeConfiguration<Ponuda>
    {
        public void Configure(EntityTypeBuilder<Ponuda> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Kontakt, k => k.WithOwner());

            IMutableNavigation? stavke = builder.Metadata.FindNavigation(nameof(Ponuda.StavkeStruktureCene));
            stavke.SetPropertyAccessMode(PropertyAccessMode.Field);

            IMutableNavigation? racuni = builder.Metadata.FindNavigation(nameof(Ponuda.TekuciRacuniPonudjaca));
            racuni.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne(p => p.JavniPoziv);
            builder.HasOne(p => p.Ponudjac);
            builder.HasOne(p => p.InformacijeOIsporuci);
           
        }
    }
}
