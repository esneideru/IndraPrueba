using Indra.EstadoCeldas.Web.Api.Dominio;
using Indra.EstadoCeldas.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indra.EstadoCeldas.Web.Api.Aplicacion
{
    public class VerificarCargaAplicacion : IVerificarCargaAplicacion
    {
        private readonly IVerificarCargaDominio _verificarCargaDominio;

        public VerificarCargaAplicacion(IVerificarCargaDominio verificarCargaDominio)
        {
            _verificarCargaDominio = verificarCargaDominio;
        }

        public CamionesResponse VerificarCarga(CamionesResquest camionesResquest)
        {
            return _verificarCargaDominio.VerificarCarga(camionesResquest);
        }
    }
}
