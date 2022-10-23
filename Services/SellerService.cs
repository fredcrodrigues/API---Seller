using Newtonsoft.Json;
using SalesDB.shared.Models;
using System.Text;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Sales.Client.Services
{

    public class SellerService : ISellerService
    {
         readonly HttpClient _httpClient;

        // client name custurms
        public SellerService(IHttpClientFactory httpfactory){
            _httpClient = httpfactory.CreateClient("APIVENDAS");
           
         }

        /*Get Seller*/
        async Task<List<Seller>> ISellerService.GetSeller()
        {
            var resquest = await _httpClient.GetAsync("api/Seller");
            var content = await resquest.Content.ReadAsStringAsync();

           
          
            return JsonConvert.DeserializeObject<List<Seller>>(content);

        }
       
        /*Get Id seller*/
        async Task<Seller> ISellerService.GetSellerId(string id)
        {
            var resquest = await _httpClient.GetAsync($"api/Seller/{id}");
            var content = await resquest.Content.ReadAsStringAsync();

         
            return JsonConvert.DeserializeObject<Seller>(content);
        }

        /*Create Seller*/
        async Task ISellerService.CreatSeller(Seller date)
        {
            var dataseller = new StringContent(
                JsonConvert.SerializeObject(date),
                Encoding.UTF8,
                Application.Json);
            
            var request = await _httpClient.PostAsync("api/Seller", dataseller);

            request.EnsureSuccessStatusCode(); ///optional
        }

        /*Update Seller*/
        async Task ISellerService.Update(string id, Seller date)
        {
            var request = await _httpClient.PutAsJsonAsync($"/api/Seller/{id}", date);


            request.EnsureSuccessStatusCode();
        }

        /*Delete seller*/
        async Task ISellerService.Delete(string id)
		{
            var request = await _httpClient.DeleteAsync($"/api/Seller/{id}");

            request.EnsureSuccessStatusCode();

        }
    }
}
