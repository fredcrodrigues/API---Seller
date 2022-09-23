using WebAPI.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace WebAPI.Services
{
    public class OpportunityService : IOpportunityService
    {
        readonly HttpClient _httpClient;

        public OpportunityService(IHttpClientFactory Ihttpfactory)
        {
            _httpClient = Ihttpfactory.CreateClient("APIVENDAS");
        }

        async Task<List<Opportunity>> IOpportunityService.GetOpporttunity()
        {
            Console.WriteLine("Testando");
            var request = await _httpClient.GetAsync("api/Oportunidade");
            var content = await request.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Opportunity>>(content);
        }

        async Task IOpportunityService.CreateOpprotunity(Opportunity date)
        {
          

            Console.WriteLine("Depois" + JsonConvert.SerializeObject(date));

            var serializerOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };


            var dataseller = new StringContent(
              JsonConvert.SerializeObject(date),
              Encoding.UTF8,
              Application.Json);

            Console.WriteLine("Data Seller " + dataseller.ReadAsStringAsync().Result);
            

            var request = await _httpClient.PostAsync("api/Oportunidade", dataseller);

            Console.WriteLine("Resultado final" + request.Content.ReadAsStringAsync().Result);
            request.EnsureSuccessStatusCode();
        }

    }
}
