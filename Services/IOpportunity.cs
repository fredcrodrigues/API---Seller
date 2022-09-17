using WebAPI.Models;
namespace WebAPI.Services
{
    public interface IOpportunity
    {
        Task<List<Opportunity>> GetOpporttunity();

     
    }
}
