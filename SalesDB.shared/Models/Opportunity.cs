using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;


namespace SalesDB.shared.Models
{
    public class Opportunity
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("cnpj")]

        public CNPJ? Cnpj { get; set; }

        [BsonElement("name")]
       
        public string? Name { get; set; }

        [BsonElement("value")]
       
        public decimal? Value { get; set; } 

        [BsonElement("seller")]
       
        public Seller? Seller { get; set; } 
    }
}
