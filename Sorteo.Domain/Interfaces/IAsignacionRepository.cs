using Sorteo.Domain.Models;
using System.Threading.Tasks;

namespace Sorteo.Domain.Interfaces
{
    public interface IAsignacionRepository
    {
        Task<Asignacion> CreateAsync(Asignacion asignacion);
        Task<bool> IsValidAsignacion(int numeroAsignacion);
    }
}
