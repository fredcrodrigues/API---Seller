using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SalesDB.Server.DTOs;
using SalesDB.shared.Models;

namespace SalesDB.Server.Service
{
	public class SellerService
	{
        /// Injeção de dependecia com mongoDB e Chamado uma coleção especifica para  a manipulação dos dados
        public readonly IMongoCollection<Seller> _configBdModels;
        public SellerService(IOptions<SettingsBD> databaseSettingsModels)
        {
            var mongoClient = new MongoClient(
               databaseSettingsModels.Value.StringConection
            );
         
            var mogoDatabase = mongoClient.GetDatabase(databaseSettingsModels.Value.NameBD);
           
            _configBdModels = mogoDatabase.GetCollection<Seller>(databaseSettingsModels.Value.CollectionSeller);
           
        }

        public async Task<List<Seller>> Get() => await _configBdModels.Find(_ => true).SortBy(x => x.Id).ToListAsync();
        public async Task<Seller> GetId(string id) => await _configBdModels.Find(x => x.Id == id).FirstOrDefaultAsync();


        public async Task Create(Seller dados)
        {

            await _configBdModels.InsertOneAsync(dados);
        }

        public async Task Update(string id, Seller updata)
        {
            await _configBdModels.ReplaceOneAsync(x => x.Id == id, updata);
        }

        public async Task Delete(string id)
        {
            await _configBdModels.DeleteOneAsync(x => x.Id == id);

        }

    }
}
