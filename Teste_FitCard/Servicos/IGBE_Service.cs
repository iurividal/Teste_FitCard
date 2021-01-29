using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Teste_FitCard.Models;

namespace Teste_FitCard.Servicos
{
    public class IGBE_Service
    {
        Uri baseAddress = new Uri("https://servicodados.ibge.gov.br/api/v1/localidades/");

        public IEnumerable<EstadosModel> GetEstados()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                var response = client.GetAsync("estados");

                response.Wait();

                var resultado = response.Result;

                return JsonConvert.DeserializeObject<IEnumerable<EstadosModel>>(resultado.Content.re().Result);
            }
        }

    }
}