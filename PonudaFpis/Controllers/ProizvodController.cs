using Core.Domain.ProizvodAggregate;
using Core.Domain.ProizvodAggregate.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PonudaFpis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        [HttpGet]
        [Route("{proizvodId}")]
        public Task<Proizvod> VratiProizvod(
            [FromServices] IProizvodRepository proizvodRepository,
            [FromRoute] Guid proizvodId)
        {
            return proizvodRepository.VratiProizvod(proizvodId);
        }
        [HttpGet]
        public async Task<IEnumerable<Proizvod>> VratiSveProizvode(
         [FromServices] IProizvodRepository proizvodRepository)
        {
            var response = await proizvodRepository.VratiProizvode();

            return response;
        }
    }
}
