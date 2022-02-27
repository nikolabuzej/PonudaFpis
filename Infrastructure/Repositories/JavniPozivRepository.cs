using Core.Abrstractions;
using Core.Domain.JavniPozivAggregate;
using Core.Domain.JavniPozivAggregate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class JavniPozivRepository : IJavniPozivRepository
    {
        private readonly PonudaDbContext _context;

        public JavniPozivRepository(PonudaDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task<JavniPoziv> VratiJavniPoziv(Guid id)
        {
            return _context.JavniPoziv.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
