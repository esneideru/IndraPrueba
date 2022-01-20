using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indra.EstadoCeldas.Web.Api.Models
{
    public class EstadoResponse
    {
        public int dias { get; set; }
        public int[] entrada { get; set; }
        public int[] salida { get; set; }
    }
}
