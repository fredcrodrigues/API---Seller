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
            var resquest = await _httpClient.GetAsync("api/Vendedor");
            var content = await resquest.Content.ReadAsStringAsync();

          
            return JsonConvert.DeserializeObject<List<Seller>>(content);

        }

        async Task ISellerService.CreatSeller(Seller date)
        {

            Console.WriteLine("Seller repsonse" + JsonConvert.SerializeObject(date));

           
           
            var dataseller = new StringContent(
                JsonConvert.SerializeObject(date),
                Encoding.UTF8,
                Application.Json);
            
            var request = await _httpClient.PostAsync("api/Vendedor", dataseller);

            request.EnsureSuccessStatusCode(); ///opional
        }
    }
}
