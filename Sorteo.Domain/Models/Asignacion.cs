using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteo.Domain.Models
{
    public class Asignacion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int ClienteId { get; set; }
    }
}
