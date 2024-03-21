using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteo.Infrastructure.Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Producto> CreateAsync(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO Producto (Nombre, Descripcion) VALUES (@Nombre, @Descripcion); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);

                    var newProductId = Convert.ToInt32(await command.ExecuteScalarAsync());

                    return new Producto
                    {
                        Id = newProductId,
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion
                    };
                }
            }
        }
    }
}
