using System.ComponentModel.DataAnnotations;
using Core.Domain.Proizvod;
namespace Core.Domain.Ponuda
{
    public class StavkaStruktureCene
    {
        public Guid Id { get;} = Guid.NewGuid();
        
        [Range(1,100)]
        public int Kolicina { get; set; } = 1;
        
        [Range(0,double.MaxValue)]
        public double JedinicnaCenaSaPdv { get; set; }
       
        [Range(0,double.MaxValue)]
        public double JedinicnaCenaBezPdv { get; set; }

        public Proizvod MyProperty { get; set; }

    }
}
