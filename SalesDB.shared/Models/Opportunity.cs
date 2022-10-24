using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;


namespace SalesDB.shared.Models
{
    public class Opportunity
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;
        
        [BsonElement("cnpj")]

        public CNPJ Cnpj { get; set; } = null!;
        
        [BsonElement("name")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; } = null!;
        
        [BsonElement("value")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal? Value { get; set; }
     
        [BsonElement("seller")]
       
        public Seller Seller { get; set; } = null!;
    }
}
