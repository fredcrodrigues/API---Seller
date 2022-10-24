using Microsoft.AspNetCore.Mvc;
using SalesDB.Server.Service;
using SalesDB.shared.Models;


namespace SalesDB.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SellerController : Controller
	{
        private readonly SellerService _sellerService;


        public SellerController(SellerService sellerService) => _sellerService = sellerService;



        [HttpGet]
        public async Task<List<Seller>>GetSeller() => await _sellerService.Get();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Seller>> GetSellerId(string id) => await _sellerService.GetId(id);

        [HttpPost]
        public async Task<IActionResult> CreateSeller(Seller date)
        {

            await _sellerService.Create(date);
            return CreatedAtAction(nameof(GetSeller), date);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateSeller(string id, Seller data) {

            var seller = await _sellerService.GetId(id);
           
            if (seller is null){

                return NotFound("Não encontrado");
            }

            data.Id = seller.Id;

            await _sellerService.Update(id, data);

            return NoContent();


        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteSeller(string id)
        {
            var seller = await _sellerService.GetId(id);

            if(seller is null)
            {
                return NotFound();
            }

            await _sellerService.Delete(id);

            return NoContent();
        }


       
    }
}
