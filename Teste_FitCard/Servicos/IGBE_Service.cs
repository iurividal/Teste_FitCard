using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using Teste_FitCard.Models;

namespace Teste_FitCard.Servicos
{
    public class IGBE_Service
    {
        Uri baseAddress = new Uri("https://servicodados.ibge.gov.br/api/v1/localidades/");
        static HttpClient client = new HttpClient();

        public IEnumerable<EstadosModel> GetEstados()
        {

            List<EstadosModel> estados = null;
            var client = new RestClient(baseAddress + "/estados");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<EstadosModel>>(response.Content);
        }

        public IEnumerable<CidadeModel> GetCidades(string uf)
        {
            var client = new RestClient(baseAddress + $"/estados/{uf}/municipios");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<CidadeModel>>(response.Content);
        }



    }
}