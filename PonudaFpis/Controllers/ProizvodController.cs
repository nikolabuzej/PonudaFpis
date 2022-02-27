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
        public Task<Proizvod> VratiSveProizvod(
            [FromServices]IProizvodRepository proizvodRepository,
            [FromRoute] Guid proizvodId)
        {
            return proizvodRepository.VratiProizvod(proizvodId);
        }
    }
}
