using ApplicationLogic.Dtos.Ponuda;
using FluentValidation;

namespace PonudaFpis.Validation
{
    public class KreirajPonuduValidacija: AbstractValidator<PonudaDto>
    {
        public KreirajPonuduValidacija()
        {
            this.RuleFor(p => p.JavniPozivId).NotEmpty().NotNull();
            this.RuleFor(p => p.ZakonskiZastupnik).NotNull();
            this.RuleFor(p => p.Status).IsInEnum();
            this.RuleFor(p => p.InformacijeOIsporuciId).NotNull().NotEmpty();
            this.RuleFor(p => p.PonudjacId).NotNull().NotEmpty();
            this.RuleFor(p => p.Kontakt).NotNull().NotEmpty();

            this.RuleFor(p => p.Kontakt).ChildRules(v =>
            {
                v.RuleFor(k => k.Email).EmailAddress();
                v.RuleFor(k => k.Telefon).Matches(@"\+3816([0-6]|9)[0-9]{6}");
                v.RuleFor(k => k.Ime).NotNull().NotEmpty();
                v.RuleFor(k => k.Prezime).NotNull().NotEmpty();
                v.RuleFor(k => k.Jmbg).Matches(@"[0-9]{13}");
            });

            this.RuleForEach(p => p.StavkeStruktureCene).ChildRules(s =>
            {
                s.RuleFor(s => s.JedinicnaCenaSaPdv).GreaterThan(1);
                s.RuleFor(s => s.JedinicnaCenaBezPdv).GreaterThan(1);
                s.RuleFor(s => s.Kolicina).GreaterThanOrEqualTo(1);
                s.RuleFor(s => s.ProizvodId).Null().NotEmpty();
            });

            this.RuleForEach(p => p.TekuciRacuniPonudjaca).ChildRules(t =>
            {
                t.RuleFor(t => t.BankaId).NotEmpty().NotNull();
                t.RuleFor(t => t.BrojRacuna).Matches(@"[0-9]{18}");
            });

        }
    }
}
