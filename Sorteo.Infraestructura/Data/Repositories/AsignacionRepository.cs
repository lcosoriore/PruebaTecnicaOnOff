using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;

namespace Sorteo.Infrastructure.Data.Repositories
{
    public class AsignacionRepository : IAsignacionRepository
    {
        private readonly ApplicationDbContext _context;

        public AsignacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Asignacion> CreateAsync(Asignacion asignacion)
        {

            _context.Asignaciones.Add(asignacion);
            await _context.SaveChangesAsync();

            return asignacion;
        }


        public async Task<bool> IsValidAsignacion(int numeroAsignacion)
        {
            return _context.Asignaciones.Any(k => k.Numero == numeroAsignacion);
        }


    }
}
