using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteo.Domain.Interfaces
{
    public interface IApiKeyRepository
    {
        string GenerateApiKey();
        bool IsValidApiKey(string apiKey);
    }
}
