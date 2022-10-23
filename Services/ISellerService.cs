using SalesDB.shared.Models;
namespace Sales.Client.Services
{
    public interface ISellerService
    {
        Task<List<Seller>> GetSeller();

        Task<Seller> GetSellerId(string id);

        Task CreatSeller(Seller date);

        Task Update(string id, Seller date);

        Task Delete(string id);

    }


}
