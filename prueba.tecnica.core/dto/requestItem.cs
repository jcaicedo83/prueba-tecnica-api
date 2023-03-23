using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.tecnica.core.dto
{
    public class requestItem
    {
        public string nombre { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string? sexo { get; set; } = null;

        public int id { get; set; }
    }
}
