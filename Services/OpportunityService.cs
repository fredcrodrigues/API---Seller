using WebAPI.Models;
using Newtonsoft.Json;
namespace WebAPI.Services
{
    public class OpportunityService : IOpportunity
    {
        readonly HttpClient _httpClient;

        OpportunityService(IHttpClientFactory Ihttpfactory)
        {
            _httpClient = Ihttpfactory.CreateClient("APIVENDAS");
        }


        async Task<List<Opportunity>> IOpportunity.GetOpporttunity()
        {
            var request = await _httpClient.GetAsync($"api/Oportunidade");
            var content = await request.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Opportunity>>(content);
        }
    }
}
