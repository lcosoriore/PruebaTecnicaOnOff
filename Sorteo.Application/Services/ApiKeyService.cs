using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using Sorteo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteo.Application.Services
{
    public class ApiKeyService 
    {
        private readonly IApiKeyRepository _apiKeyRepository;

        public ApiKeyService(IApiKeyRepository apiKeyRepository)
        {
            _apiKeyRepository = apiKeyRepository;
        }

        public string GenerateApiKey()
        {
            // Generar y almacenar la clave de API en la base de datos
            var apiKey = Guid.NewGuid().ToString();
            _apiKeyRepository.GenerateApiKey();
            return apiKey;
        }

        public bool IsValidApiKey(string apiKey)
        {
            // Verificar si la clave de API es válida
            return _apiKeyRepository.IsValidApiKey(apiKey);
        }
    }

}
