using Indra.EstadoCeldas.Web.Api.Aplicacion;
using Indra.EstadoCeldas.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Indra.EstadoCeldas.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCeldasController : Controller
    {
        private readonly IVerificarEstadoAplicacion _verificarEstadoAplicacion;

        public EstadoCeldasController(IVerificarEstadoAplicacion verificarEstadoAplicacion)
        {
            _verificarEstadoAplicacion = verificarEstadoAplicacion;
        }   


        [HttpPost("verficarEstado")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(504)]
        public IActionResult VerficarEstado([FromBody] EstadoRequest estadoRequest )
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _verificarEstadoAplicacion.VerificarEstado(estadoRequest));
            }
            catch (Exception  ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A ocurrido un error interno, intentelo nuevamente, " + ex.Message);
            }
        }

     
    }
}
