using WebAPI.Models;
namespace WebAPI.Services
{
    public interface IOpportunityService
    {
        Task<List<Opportunity>> GetOpporttunity();

        Task CreateOpprotunity(Opportunity date);
    }
}
