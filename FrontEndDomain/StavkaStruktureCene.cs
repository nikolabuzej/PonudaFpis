using System.ComponentModel.DataAnnotations;

namespace FrontEnd.FrontEndDomain
{
    public class StavkaStruktureCene
    {
        public Guid Id { get; set; }

        public Guid PonudaId { get; set; }

        [Range(1, 100)]
        public int Kolicina { get; set; } = 1;

        [Range(0, double.MaxValue)]
        public double JedinicnaCenaSaPdv { get; set; }

        [Range(0, double.MaxValue)]
        public double JedinicnaCenaBezPdv { get; set; }

        public Proizvod Proizvod { get; set; } = new();

    }
}