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
        public DbSet<Ponuda> Ponude { get; set; }
        public DbSet<JavniPoziv> JavniPozivi { get; set; }
        public DbSet<InformacijeOIsporuci> InformacijeOIsporukama { get; set; }
        public DbSet<Banka> Banke { get; set; }
        public DbSet<StavkaStruktureCene> StavkeStruktureCene { get; set; }
        public DbSet<TekuciRacunPonudjaca> TekuciRacuniPonudjaca { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }

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
