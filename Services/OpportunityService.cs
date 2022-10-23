using SalesDB.shared.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace Sales.Client.Services
{
    public class OpportunityService : IOpportunityService
    {
        readonly HttpClient _httpClient;

        public OpportunityService(IHttpClientFactory Ihttpfactory)
        {
            _httpClient = Ihttpfactory.CreateClient("APIVENDAS");
        }

        //Get Opportunity
        async Task<List<Opportunity>> IOpportunityService.Get()
        {
          
            var request = await _httpClient.GetAsync("api/Opportunity");
            var content = await request.Content.ReadAsStringAsync();


            var teste = JsonConvert.DeserializeObject<List<Opportunity>>(content);
       
          
            return JsonConvert.DeserializeObject<List<Opportunity>>(content);
        }

        //Get Id
        async Task<Opportunity> IOpportunityService.GeId(string id)
        {
            var resquest = await _httpClient.GetAsync($"api/Opportunity/{id}");
            var content = await resquest.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Opportunity>(content);
        }

        //Create
        async Task IOpportunityService.Create(Opportunity date)
        {
          
           


            var dataseller = new StringContent(
              JsonConvert.SerializeObject(date),
              Encoding.UTF8,
              Application.Json);

          
            var request = await _httpClient.PostAsync("api/Opportunity", dataseller);

           
            request.EnsureSuccessStatusCode();
        }


        //update
       /* async Task IOpportunityService.Update(string id, Opportunity date)
        {
            var request = await _httpClient.PutAsJsonAsync($"/api/opportunity/{id}", date);

            Console.WriteLine("Dados Alterado com Sucesso");

            request.EnsureSuccessStatusCode();
        }*/

        //Delete
        async Task IOpportunityService.Delete(string id)
        {
            var request = await _httpClient.DeleteAsync($"/api/opportunity/{id}");

            request.EnsureSuccessStatusCode();

        }

    }
}
