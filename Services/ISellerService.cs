using WebAPI.Models;
namespace WebAPI.Services
{
    public interface ISellerService
    {
        Task<List<Seller>> GetSeller();

        Task CreatSeller(Seller date);

    }


}
