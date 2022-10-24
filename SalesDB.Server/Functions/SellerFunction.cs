using SalesDB.shared.Models;

namespace SalesDB.Server.Functions
{
	public class SellerFunction
	{

        // Função Roleta que verifica se o o vendedor já está cadastrado em uma oportunidade ou não
        public static Seller Roleta(Seller seller, List<Opportunity> opportunity)
        {
           
            foreach (var item in opportunity)
            {

                if (item.Seller.Id == seller.Id)
                {
                    seller = null;
                    break;
                }
            }

            return seller;
        }
    }

}

