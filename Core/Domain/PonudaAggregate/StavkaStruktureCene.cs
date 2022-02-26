using Core.Domain.ProizvodAggregate;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.PonudaAggregate
{
    public class StavkaStruktureCene
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public Guid PonudaId { get; init; }

        [Range(1, 100)]
        public int Kolicina { get; set; } = 1;

        [Range(0, double.MaxValue)]
        public double JedinicnaCenaSaPdv { get; set; }

        [Range(0, double.MaxValue)]
        public double JedinicnaCenaBezPdv { get; set; }

        public Proizvod Proizvod { get; set; } = new();

    }
}