using Indra.EstadoCeldas.Web.Api.Dominio;
using Indra.EstadoCeldas.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indra.EstadoCeldas.Web.Api.Aplicacion
{
    public class VerificarEstadoAplicacion : IVerificarEstadoAplicacion
    {
        private readonly IVerificarEstadoDominio _verificarEstadoDominio;

        public VerificarEstadoAplicacion(IVerificarEstadoDominio verificarEstadoDominio)
        {
            _verificarEstadoDominio = verificarEstadoDominio;
        }

        public EstadoResponse VerificarEstado(EstadoRequest estadoRequest)
        {
            return _verificarEstadoDominio.VerificarEstado(estadoRequest);
        }
    }
}
