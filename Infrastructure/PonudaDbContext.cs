using Core.Abrstractions;
using Core.Domain.BankaAggregate;
using Core.Domain.InformacijeOIsporuciAggregate;
using Core.Domain.JavniPozivAggregate;
using Core.Domain.PonudaAggregate;
using Core.Domain.PonudjacAggregate;
using Core.Domain.ProizvodAggregate;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PonudaDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Ponuda> Ponuda { get; set; }
        public DbSet<JavniPoziv> JavniPoziv { get; set; }
        public DbSet<InformacijeOIsporuci> InformacijeOIsporuci { get; set; }
        public DbSet<Banka> Banka { get; set; }
        public DbSet<StavkaStruktureCene> StavkaStruktureCene { get; set; }
        public DbSet<TekuciRacunPonudjaca> TekuciRacunPonudjaca { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Ponudjac> Ponudjac { get; set; }

        public PonudaDbContext(DbContextOptions<PonudaDbContext> context):base(context)
        {
        }

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
