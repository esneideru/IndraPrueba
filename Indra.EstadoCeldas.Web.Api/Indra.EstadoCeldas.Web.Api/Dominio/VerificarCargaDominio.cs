using Indra.EstadoCeldas.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indra.EstadoCeldas.Web.Api.Dominio
{
    public class VerificarCargaDominio : IVerificarCargaDominio
    {
        public CamionesResponse VerificarCarga(CamionesResquest camionesResquest)
        {
            string message;
            CamionesResponse lstCarga = new CamionesResponse();

            if (camionesResquest.tamanioCamion <= 30)
            {
                message = "El camion no puede llevar ningun paquete, no tiene la capacidad para hacerlo";
                lstCarga.paquetes = message;
            }
            else
            {
                lstCarga = generatelistaCarga(camionesResquest.tamanioCamion, camionesResquest.lstPaquetes);
            }

            return lstCarga;
        }

        private CamionesResponse generatelistaCarga(int tamanioCamion, int[] listaCarga)
        {
            int valorDesocupado = tamanioCamion - 30;
            var values = new Dictionary<string, int>();

            for (int i = 0; i < listaCarga.Length; i++)
            {
                for (int j = 0; j < listaCarga.Length; j++)
                {
                    if (i != j)
                    {
                        int sum = listaCarga[i] + listaCarga[j];
                        values.Add(listaCarga[i] + ", " + listaCarga[j], sum);
                    }
                }
            }

            var paquetes = new List<int>();
            int major = 0;

            foreach (var item in values)
            {
                if (item.Value <= valorDesocupado)
                {
                    if (item.Value >= major)
                    {
                        paquetes.Add(item.Value);
                    }
                }
            }

            int majorvalue = paquetes.Max();
            var valuesToTransport = values.Where(x => x.Value == majorvalue).Select(pair => pair.Key).ToArray();


            return generateRespuestaServicio(valuesToTransport[0]);
        }

        private CamionesResponse generateRespuestaServicio(string valuesToTransport)
        {
            return new CamionesResponse()
            {
                paquetes = "[" + valuesToTransport + "]"
            };
        }
    }
}
