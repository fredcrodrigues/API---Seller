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
        public string? Id { get; set; } = null!;

        [BsonElement("name")]
        [Required( ErrorMessage="Campo Obrigatório")]
        public string Name { get; set; } = null!;

        [BsonElement("email")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; } = null!;
       
        [BsonElement("region")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
		[Required(ErrorMessage = "Campo Obrigatório")]
        public Regions Region { get; set; }
    }
}
