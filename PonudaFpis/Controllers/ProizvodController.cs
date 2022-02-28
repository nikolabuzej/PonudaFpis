using Core.Domain.ProizvodAggregate;
using Core.Domain.ProizvodAggregate.Repositories;
using Core.ListView;
using Microsoft.AspNetCore.Mvc;
using PonudaFpis.Model;

namespace PonudaFpis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        [HttpGet]
        [Route("{proizvodId}")]
        public Task<Proizvod> VratiProizvod(
            [FromServices]IProizvodRepository proizvodRepository,
            [FromRoute] Guid proizvodId)
        {
            return proizvodRepository.VratiProizvod(proizvodId);
        }
        [HttpGet]
        public async Task<ListViewModel<Proizvod>> VratiSveProizvode([FromQuery] PaginationParameters parameters,
         [FromServices] IProizvodRepository proizvodRepository)
        {
            var response = await proizvodRepository.VratiProizvode(parameters);

            return new()
            {
                Data = response,
                Pagination = new(response.CurrentPage, response.TotalPages, response.PageSize, response.Count)
            };
        }
    }
}
