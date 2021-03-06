using ApplicationLogic.Abstractions.UseCase;
using ApplicationLogic.Dtos.AzurirajPonudu;
using ApplicationLogic.Dtos.Ponuda;
using ApplicationLogic.UseCases.AzurirajPonudu;
using ApplicationLogic.UseCases.IzbrisiPonudu;
using ApplicationLogic.UseCases.KreirajPonudu;
using ApplicationLogic.UseCases.VratiPonude;
using ApplicationLogic.UseCases.VratiPonudu;
using Core.Domain.PonudaAggregate;
using Core.ListView;
using Microsoft.AspNetCore.Mvc;
using PonudaFpis.Model;

namespace PonudaFpis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PonudaController : ControllerBase
    {
        [HttpPost]
        public async Task<Ponuda> KreirajPonudu([FromServices] IUseCase<KreirajPonuduZahtev, KreirajPonuduOdgovor> useCase,
                                          [FromBody] PonudaDto payload)
        {
            KreirajPonuduOdgovor rezultat = await useCase.ExecuteAsync(new() { PonudaDto = payload });

            return rezultat.Ponuda;
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<Ponuda> AzurirajPonudu([FromRoute] Guid id,
                                                 [FromBody] AzurirajPonuduDto ponudaDto,
                                                 [FromServices] IUseCase<AzurirajPonuduZahtev, AzurirajPonuduOdgovor> useCase)
        {
            var rezultat = await useCase.ExecuteAsync(new() { Id = id, PonudaDto = ponudaDto });

            return rezultat.Ponuda;
        }
        [HttpGet]
        public async Task<ListViewModel<Ponuda>> VratiPonude([FromQuery] PaginationParameters paginationParameters,
            [FromServices] IUseCase<VratiPonudeZahtev, VratiPonudeOdgovor> useCase)
        {
            VratiPonudeOdgovor lista = await useCase.ExecuteAsync(new() { Pagination = paginationParameters });

            return new()
            {
                Data = lista.Ponude,
                Pagination = new(lista.Ponude.CurrentPage,
                                 lista.Ponude.TotalPages,
                                 lista.Ponude.PageSize,
                                 lista.Ponude.Count,
                                 paginationParameters.SortProperty,
                                 paginationParameters.SortOrder,
                                 paginationParameters.SearchText)
            };
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Ponuda> VratiPonudu([FromRoute] Guid id,
                                              [FromServices] IUseCase<VratiPonuduZahtev, VratiPonuduOdgovor> useCase)
        {
            VratiPonuduOdgovor response = await useCase.ExecuteAsync(new() { Id = id });

            return response.Ponuda;
        }
        [HttpDelete]
        [Route("{id}")]
        public Task IzbrisiPonudu([FromRoute] Guid id,
                                  [FromServices] IUseCase<IzbrisiPonuduZahtev> useCase)
        {
            return useCase.ExecuteAsync(new() { Id = id });
        }

    }
}
