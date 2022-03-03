using Core.Domain.PonudjacAggregate;
using Core.Domain.PonudjacAggregate.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PonudaFpis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PonudjacController : ControllerBase
    {
        private readonly IPonudjacRepository _repository;

        public PonudjacController(IPonudjacRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<IEnumerable<Ponudjac>> VratiPonudjace()
        {
            return _repository.VratiPonudjace();
        }
    }
}
