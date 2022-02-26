using Core.Abrstractions;
using Core.Domain.BankaAggregate;
using Core.Domain.InformacijeOIsporuciAggregate;
using Core.Domain.JavniPozivAggregate;
using Core.Domain.PonudaAggregate;
using Core.Domain.ProizvodAggregate;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PonudaDbContext : DbContext, IUnitOfWork
    {
        DbSet<Ponuda> Ponude { get; set; }
        DbSet<JavniPoziv> JavniPozivi { get; set; }
        DbSet<InformacijeOIsporuci> InformacijeOIsporukama { get; set; }
        DbSet<Banka> Banke { get; set; }
        DbSet<StavkaStruktureCene> StavkeStruktureCene { get; set; }
        DbSet<TekuciRacunPonudjaca> TekuciRacuniPonudjaca { get; set; }
        DbSet<Proizvod> Proizvodi { get; set; }

        public Task SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PonudaConfiguration).Assembly);
        }

    }
}
