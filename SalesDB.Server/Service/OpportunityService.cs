using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SalesDB.shared.Models;
using SalesDB.Server.DTOs;

namespace SalesDB.Server.Service
{
	public class OpportunityService 
	{
        /// Injeção de dependecia com mongoDB e Chamado uma coleção especifica para  amanipulação dos dados
        public readonly  IMongoCollection<Opportunity> _configBdModels;


        public OpportunityService(IOptions<SettingsBD> databaseSettingsModels)
        {

            var mongoClient = new MongoClient(databaseSettingsModels.Value.StringConection);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettingsModels.Value.NameBD);
            _configBdModels = mongoDatabase.GetCollection<Opportunity>(databaseSettingsModels.Value.CollectionOpportunity);

        }

        public async Task<List<Opportunity>> Get() => await _configBdModels.Find(_ => true).SortBy(x => x.Seller.Id).ToListAsync();

        public async Task<Opportunity> GetId(string id) => await _configBdModels.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task Create(Opportunity dados)
        {

            await _configBdModels.InsertOneAsync(dados);

        }

        public async Task Delete(string id)
        {
            await _configBdModels.DeleteOneAsync(x => x.Id == id);

        }

    }
}
