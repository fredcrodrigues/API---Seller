using Microsoft.AspNetCore.Mvc;

namespace SalesDB.Server.Service
{
	public class ApiService
	{
        // Injeção de dependência para o uso do HTTPCLINT e chamar a api externa

        public readonly IHttpClientFactory _IhttpClientFactory;

        public ApiService(IHttpClientFactory Ihttpclient)
        {
            _IhttpClientFactory = Ihttpclient;
        }


        public async Task<string> GetApi(string cpnj)
        {

            var httpclient = _IhttpClientFactory.CreateClient("apicnpj");
            var URL = $"cnpj/{cpnj}";
            var resposta = await httpclient.GetAsync(URL);


            return await resposta.Content.ReadAsStringAsync();



        }

    }
}

