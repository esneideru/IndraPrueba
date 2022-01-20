using Indra.EstadoCeldas.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indra.EstadoCeldas.Web.Api.Dominio
{
    public interface IVerificarEstadoDominio
    {
        public EstadoResponse VerificarEstado(EstadoRequest estadoRequest);
    }
}
