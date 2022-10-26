using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SalesDB.shared.Models
{

    public enum Regions
    {
        Vazio = 0,
        Norte = 1,
        Nordeste = 2,
        Sudeste = 3,
        Centro_Oeste = 4,
        Sul = 5
    }
    public class Seller
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        [BsonElement("name")]
        
        public string? Name { get; set; }

        [BsonElement("email")]
      
        public string? Email { get; set; } 

        [BsonElement("region")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
	
        public Regions Region { get; set; } 
    }
}
