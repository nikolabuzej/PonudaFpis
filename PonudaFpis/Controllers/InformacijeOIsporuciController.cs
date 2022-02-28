using Core.Domain.InformacijeOIsporuciAggregate;
using Core.Domain.InformacijeOIsporuciAggregate.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PonudaFpis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformacijeOIsporuciController : ControllerBase
    {
        private readonly IInformacijeOIsporuciRepository _repository;

        public InformacijeOIsporuciController(IInformacijeOIsporuciRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<IEnumerable<InformacijeOIsporuci>> VratiInformacijeOIsporuci()
        {
            return _repository.VratiInformacijeOIsporuci();
        }
    }
}
