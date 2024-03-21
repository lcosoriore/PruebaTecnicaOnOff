using Sorteo.Domain.Models;
using System.Threading.Tasks;

namespace Sorteo.Domain.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto> CreateAsync(Producto producto);
    }
}
