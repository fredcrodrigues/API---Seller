using Newtonsoft.Json;
using WebAPI.Models;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace WebAPI.Services
{

    public class SellerService : ISellerService
    {
         readonly HttpClient _httpClient;
        
         public SellerService(IHttpClientFactory httpfactory){   // client name custurms
            _httpClient = httpfactory.CreateClient("APIVENDAS");
           
         }

        async Task<List<Seller>> ISellerService.GetSeller()
        {
            var response = await _httpClient.GetAsync("api/Vendedor");
            var content = await response.Content.ReadAsStringAsync();

            var testa = JsonConvert.DeserializeObject<List<Models.Seller>>(content);


            return JsonConvert.DeserializeObject<List<Models.Seller>>(content);

        }

        async Task ISellerService.CreatSeller(Seller date)
        {
            
           
            var dataseller = new StringContent(
                JsonConvert.SerializeObject(date),
                Encoding.UTF8,
                Application.Json);
            
            var response = await _httpClient.PostAsync("api/Vendedor", dataseller);

            response.EnsureSuccessStatusCode();
        }
    }
}
