using Indra.EstadoCeldas.Web.Api.Models;


namespace Indra.EstadoCeldas.Web.Api.Dominio
{
    public class VerificarEstadoDominio : IVerificarEstadoDominio
    {
        private int estadoPrevio = 0;

        public EstadoResponse VerificarEstado(EstadoRequest estadoRequest)
        {
            int lastIndex = estadoRequest.lstCasas.Length - 1;
            var casasPrevio = (int[])estadoRequest.lstCasas.Clone();

            for (int i = 0; i < estadoRequest.dias; i++)
            {
                for (int j = 0; j < estadoRequest.lstCasas.Length; j++)
                {
                    int nuevoEstado = 0;

                    if (j == 0)
                    {
                        nuevoEstado  = checkEstado(0, estadoRequest.lstCasas[j+1]);
                    }
                    else if (j == lastIndex)
                    {
                        nuevoEstado = checkEstado(estadoPrevio, 0);
                    }
                    else
                    {
                        nuevoEstado = checkEstado(estadoPrevio, estadoRequest.lstCasas[j + 1]);
                    }

                    estadoPrevio = estadoRequest.lstCasas[j];
                    estadoRequest.lstCasas[j] = nuevoEstado;
                }
            }

            return generateRespuestaServicio(estadoRequest.dias, casasPrevio, estadoRequest.lstCasas); 
        }

        private int checkEstado(int izq, int der)
        {
            int estado = 1;

            if (izq == 0 && der == 0 || izq == 1 &&  der == 1)
            {
                estado = 0;
            }

            return estado;
        }


        private EstadoResponse generateRespuestaServicio(int dias, int[] casasPrevio, int[] casasActual)
        {
            return new EstadoResponse()
            {
                dias = dias,
                entrada = casasPrevio,
                salida = casasActual
            };
        }

    }
}
