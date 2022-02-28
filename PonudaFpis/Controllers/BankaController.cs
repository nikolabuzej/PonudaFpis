using Core.Domain.BankaAggregate;
using Core.Domain.BankaAggregate.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PonudaFpis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankaController : ControllerBase
    {
        private readonly IBankaRepository _bankaRepository;

        public BankaController(IBankaRepository bankaRepository)
        {
            _bankaRepository = bankaRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Banka>> VratiPonude()
        {
            return _bankaRepository.VratiBanke();
        }
    }
}
