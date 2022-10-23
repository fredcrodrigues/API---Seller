using SalesDB.shared.Models;
namespace Sales.Client.Services
{
    public interface IOpportunityService
    {
        Task<List<Opportunity>> Get();

        Task<Opportunity> GeId(string id);

        Task Create(Opportunity date);

      /*  Task Update(string id, Opportunity date);*/

        Task Delete(string id);

    }
}
