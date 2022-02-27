using ApplicationLogic.Abstractions.UseCase;
using ApplicationLogic.Dtos.AzurirajPonudu;
using ApplicationLogic.Dtos.Ponuda;
using Core.Domain.BankaAggregate;
using Core.Domain.BankaAggregate.Repositories;
using Core.Domain.InformacijeOIsporuciAggregate;
using Core.Domain.InformacijeOIsporuciAggregate.Repositories;
using Core.Domain.JavniPozivAggregate;
using Core.Domain.JavniPozivAggregate.Repositories;
using Core.Domain.PonudaAggregate;
using Core.Domain.PonudaAggregate.Repositories;
using Core.Domain.PonudjacAggregate;
using Core.Domain.PonudjacAggregate.Repositories;
using Core.Domain.ProizvodAggregate;
using Core.Domain.ProizvodAggregate.Repositories;
using Core.Extensions;

namespace ApplicationLogic.UseCases.AzurirajPonudu
{
    public class AzurirajPonuduSlucajKoriscenja : IUseCase<AzurirajPonuduZahtev, AzurirajPonuduOdgovor>
    {
        private readonly IPonudaRepository _ponudaRepository;
        private readonly IProizvodRepository _proizvodRepository;
        private readonly IInformacijeOIsporuciRepository _informacijeOIsporuciRepository;
        private readonly IPonudjacRepository _ponudjacRepository;
        private readonly IBankaRepository _bankaRepository;
        private readonly IJavniPozivRepository _javniPozivRepository;

        public AzurirajPonuduSlucajKoriscenja(IPonudaRepository ponudaRepository,
                                              IProizvodRepository proizvodRepository,
                                              IInformacijeOIsporuciRepository informacijeOIsporuciRepository,
                                              IPonudjacRepository ponudjacRepository,
                                              IBankaRepository bankaRepository,
                                              IJavniPozivRepository javniPozivRepository)
        {
            _ponudaRepository = ponudaRepository;
            _proizvodRepository = proizvodRepository;
            _informacijeOIsporuciRepository = informacijeOIsporuciRepository;
            _ponudjacRepository = ponudjacRepository;
            _bankaRepository = bankaRepository;
            _javniPozivRepository = javniPozivRepository;
        }

        public async Task<AzurirajPonuduOdgovor> ExecuteAsync(AzurirajPonuduZahtev request)
        {
            Ponuda ponuda = await _ponudaRepository.VratiPonudu(request.Id).EnsureExists();
            JavniPoziv javniPoziv = await _javniPozivRepository.VratiJavniPoziv(request.PonudaDto.JavniPozivId).EnsureExists();
            Ponudjac ponudjac = await _ponudjacRepository.VratiPonudjaca(request.PonudaDto.PonudjacId).EnsureExists();
            InformacijeOIsporuci informacijeOIsporuci = await _informacijeOIsporuciRepository
                .VratiInformacijeOIsporuci(request.PonudaDto.InformacijeOIsporuciId)
                .EnsureExists();
            Kontakt kontakt = new()
            {
                Email = request.PonudaDto.Kontakt.Email,
                Ime = request.PonudaDto.Kontakt.Ime,
                Prezime = request.PonudaDto.Kontakt.Prezime,
                Jmbg = request.PonudaDto.Kontakt.Jmbg,
                Telefon = request.PonudaDto.Kontakt.Telefon
            };

            ponuda.Update(kontakt,
               request.PonudaDto.DatumPristizanja,
               request.PonudaDto.ZakonskiZastupnik,
               request.PonudaDto.Status,
               javniPoziv,
               ponudjac,
               informacijeOIsporuci
               );
            await DodajStavke(request.PonudaDto.StavkeStruktureCene, ponuda);
            await DodajRacune(request.PonudaDto.TekuciRacuniPonudjaca, ponuda);

            await _ponudaRepository.AzurirajPonudu(ponuda);
            await _ponudaRepository.UnitOfWork.SaveChangesAsync();

            return new(ponuda);
        }
        private async Task DodajStavke(IEnumerable<AzurirajStavkuDto> stavkeDto, Ponuda ponuda)
        {
            foreach (StavkaStruktureCene stara in ponuda.StavkeStruktureCene.ToList())
            {
                if (!stavkeDto.Any(s => s.Id == stara.Id))
                {
                    ponuda.ObrisiStavkuStruktureCene(stara.Id);
                }
            }
            foreach (var stavka in stavkeDto)
            {
                Proizvod proizvod = await _proizvodRepository.VratiProizvod(stavka.ProizvodId).EnsureExists();
                if (stavka.Id != Guid.Empty)
                {
                    ponuda.AzurirajStavkuStruktureCene(stavka.Id, stavka.Kolicina, stavka.JedinicnaCenaBezPdv, stavka.JedinicnaCenaSaPdv, proizvod);
                }
                else
                {
                    ponuda.DodajStavkuStruktureCene(stavka.Kolicina, stavka.JedinicnaCenaBezPdv, stavka.JedinicnaCenaSaPdv, proizvod);
                }
            }

        }
        private async Task DodajRacune(IEnumerable<AzurirajTekuciDto> racuniDto, Ponuda ponuda)
        {
            foreach (TekuciRacunPonudjaca stari in ponuda.TekuciRacuniPonudjaca.ToList())
            {
                if (!racuniDto.Any(r => r.Id == stari.Id))
                {
                    ponuda.ObrisiTekuciRacunPonudjaca(stari.Id);
                }
            }
            foreach (var racun in racuniDto)
            {
                Banka banka = await _bankaRepository.VratiBanku(racun.BankaId).EnsureExists();
                if (racun.Id != Guid.Empty)
                {
                    ponuda.AzurirajTekuciRacunPonudjaca(racun.Id, racun.BrojRacuna, banka);
                }
                else
                {
                    ponuda.DodajTekuciRacunPonudjaca(racun.BrojRacuna, banka);
                }
            }
        }
    }
}
