using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sorteo.Application.Services
{
    public class AsignacionService
    {
        private readonly IAsignacionRepository _asignacionRepository;
        private readonly Random _random;

        public AsignacionService(IAsignacionRepository asignacionRepository)
        {
            _asignacionRepository = asignacionRepository;
            _random = new Random();
        }

        public async Task<Asignacion> AsignarNumeroAsync(int numero, int clienteId)
        {
            var asignacion = new Asignacion { Numero = numero, ClienteId = clienteId };
            return await _asignacionRepository.CreateAsync(asignacion);
        }
        public async Task<Asignacion> AsignarNumeroAsync(int clienteId)
        {
            // Generar un número aleatorio único que cumpla con las restricciones
            string numeroAsignado;
            do
            {
                numeroAsignado = GenerarNumeroAleatorio();
            } 
            while (!ValidarNumero(numeroAsignado) || await _asignacionRepository.IsValidAsignacion(Convert.ToInt32(numeroAsignado)));

            // Crear la asignación y persistirla en la base de datos
            var asignacion = new Asignacion { Numero = Convert.ToInt32(numeroAsignado), ClienteId = clienteId };
            await _asignacionRepository.CreateAsync(asignacion);

            return asignacion;
        }

        private string GenerarNumeroAleatorio()
        {
            return _random.Next(10000, 99999).ToString(); // Generar un número aleatorio de 5 dígitos
        }

        private bool ValidarNumero(string numero)
        {
            // Validar que el número tenga 5 dígitos y no tenga más de 3 dígitos consecutivos iguales
            if (numero.Length != 5)
                return false;

            for (int i = 0; i < numero.Length - 2; i++)
            {
                if (numero[i] == numero[i + 1] && numero[i] == numero[i + 2])
                    return false;
            }

            return true;
        }

    }
}
