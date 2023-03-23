using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.tecnica.core.dto
{
    public  class ResponseItem
    {
        public bool ok { get; set; }

        public string mensaje { get; set; }

        public object resultado { get; set; }
    }
}
