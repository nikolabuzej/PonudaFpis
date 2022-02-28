using Core.Domain.JavniPozivAggregate;
using Core.Domain.JavniPozivAggregate.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PonudaFpis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JavniPozivController : ControllerBase
    {
        private readonly IJavniPozivRepository _javniPozivRepository;

        public JavniPozivController(IJavniPozivRepository javniPozivRepository)
        {
            _javniPozivRepository = javniPozivRepository;
        }

        [HttpGet]
        public Task<IEnumerable<JavniPoziv>> VratiJavnePozive()
        {
            return _javniPozivRepository.VratiJavnePozive();
        }
    }
}
