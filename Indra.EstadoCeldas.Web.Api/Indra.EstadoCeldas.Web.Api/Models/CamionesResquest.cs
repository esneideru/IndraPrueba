using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Indra.EstadoCeldas.Web.Api.Models
{
    public class CamionesResquest
    {
        [JsonProperty("lstPaquetes")]
        [Required(ErrorMessage = "La lista de paquetes es requerida")]
        public int[] lstPaquetes { get; set; }

        [JsonProperty("tamanioCamion")]
        [Required(ErrorMessage = "El tamaño del camion es Requerido")]

        public int tamanioCamion { get; set; }
    }
}
