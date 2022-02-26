using ApplicationLogic.Abstractions.UseCase;
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

namespace ApplicationLogic.UseCases.KreirajPonudu
{
    public class KreirajPonuduSlucajKoriscenja : IUseCase<KreirajPonuduZahtev, KreirajPonuduOdgovor>
    {
        private readonly IPonudaRepository _ponudaRepository;
        private readonly IProizvodRepository _proizvodRepository;
        private readonly IInformacijeOIsporuciRepository _informacijeOIsporuciRepository;
        private readonly IPonudjacRepository _ponudjacRepository;
        private readonly IBankaRepository _bankaRepository;
        private readonly IJavniPozivRepository _javniPozivRepository;

        public KreirajPonuduSlucajKoriscenja(IPonudaRepository ponudaRepository,
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

        public async Task<KreirajPonuduOdgovor> ExecuteAsync(KreirajPonuduZahtev request)
        {
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

            Ponuda ponuda = new(kontakt,
                request.PonudaDto.DatumPristizanja,
                request.PonudaDto.ZakonskiZastupnik,
                request.PonudaDto.Status,
                javniPoziv,
                ponudjac,
                informacijeOIsporuci
                );
            await DodajStavke(request.PonudaDto.StavkeStruktureCene,ponuda);
            await DodajRacune(request.PonudaDto.TekuciRacuniPonudjaca,ponuda);

            await _ponudaRepository.KreirajPonudu(ponuda);
            await _ponudaRepository.UnitOfWork.SaveChangesAsync();

            return new(ponuda);

        }

        private async Task DodajStavke(IEnumerable<StavkaStruktureCeneDto> stavkeDto,Ponuda ponuda)
        {
            foreach (var stavka in stavkeDto)
            {
                Proizvod proizvod = await _proizvodRepository.VratiProizvod(stavka.ProizvodId).EnsureExists();
                ponuda.DodajStavkuStruktureCene(stavka.Kolicina,stavka.JedinicnaCenaBezPdv,stavka.JedinicnaCenaSaPdv,proizvod);
            }
        }
        private async Task DodajRacune(IEnumerable<TekuciRacunPonudjacaDto> racuniDto, Ponuda ponuda)
        {
            foreach (var racun in racuniDto)
            {
                Banka banka= await _bankaRepository.VratiBanku(racun.BankaId).EnsureExists();
                ponuda.DodajTekuciRacunPonudjaca(racun.BrojRacuna, banka);
            }
        }

    }
}
