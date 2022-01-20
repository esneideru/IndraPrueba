using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Indra.EstadoCeldas.Web.Api.Models
{
    public class EstadoRequest
    {
        [JsonProperty("lstCasas")]
        [Required(ErrorMessage = "La lista de casas es requerida")]
        public int[] lstCasas { get; set; }

        [JsonProperty("dias")]
        [Required(ErrorMessage = "El número de dias es Requerido")]

        public int dias { get; set; }
    }
}
