using Indra.EstadoCeldas.Web.Api.Aplicacion;
using Indra.EstadoCeldas.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Indra.EstadoCeldas.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamionesController : Controller
    {
        private readonly IVerificarCargaAplicacion _verificarCargaAplicacion;

        public CamionesController(IVerificarCargaAplicacion verificarCargaAplicacion)
        {
            _verificarCargaAplicacion = verificarCargaAplicacion;
        }


        [HttpPost("verficarCarga")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(504)]
        public IActionResult VerficarEstado([FromBody] CamionesResquest camionesRequest)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _verificarCargaAplicacion.VerificarCarga(camionesRequest));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A ocurrido un error interno, intentelo nuevamente, " + ex.Message);
            }
        }
    }
}
