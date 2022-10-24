using Microsoft.AspNetCore.Mvc;
using SalesDB.shared.Models;
using SalesDB.Server.Functions;
using SalesDB.Server.Service;
using Newtonsoft.Json.Linq;


namespace SalesDB.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]


    public class OpportunityController : Controller
    {
        public readonly OpportunityService _opportunityService;
        public readonly SellerService _sellerService;
        public readonly ApiService _apiService;


        public OpportunityController(OpportunityService opportunityService, ApiService apiService, SellerService sellerService)
        {
            _opportunityService = opportunityService;
            _apiService = apiService;
            _sellerService = sellerService;


        }



        [HttpGet]
        public async Task<List<Opportunity>> GetOpportunity() => await _opportunityService.Get();


        [HttpGet("{id:length(24)}")]

        public async Task<ActionResult<Opportunity>> GetOpportunityId(string id)
        {

            var sellerOpportunity = await _opportunityService.GetId(id);

            if (sellerOpportunity is null)

                NotFound();

            return sellerOpportunity;
        }


        [HttpPost]
        public async Task<IActionResult> Create(Opportunity date)
        {
            // obtem dados do cnpj de ooutra API
            var dataCnpj = await _apiService.GetApi(date.Cnpj.Number);

            // obtem dados do Vendedor
            var seller = await _sellerService.GetId(date.Seller.Id);


            var opportunity = await _opportunityService.Get();
            // Cria um Objeto Json
            JObject jobject = JObject.Parse(dataCnpj);


            // Cria novo cnpj atraves do Tokens Json
            var cnpj = new CNPJ
            {
                Number = date.Cnpj.Number,
                Social_reason = jobject.SelectToken("razao_social").ToString(),
                State = jobject.SelectToken("estabelecimento.estado.nome").ToString(),
                Activity = jobject.SelectToken("estabelecimento.atividade_principal.descricao").ToString()
            };



            date.Cnpj = cnpj;
            date.Seller = (opportunity.Count() == 0) ? seller : SellerFunction.Roleta(seller, opportunity);

            var nflag = OpportunityFunction.VerificaRegiao(date);


            /// Ver melhorias //
            if (nflag)
            {
                await _opportunityService.Create(date);

            }


            return (!nflag) ? NotFound("Vendedor não pose ser cadastrado") : CreatedAtAction(nameof(GetOpportunity), date);

        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteOpportunity(string id)
        {
            var opportunity = await _opportunityService.GetId(id);

            if (opportunity is null)
            {
                return NotFound();
            }

            await _opportunityService.Delete(id);

            return NoContent();
        }

    }

}

