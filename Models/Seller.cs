using System.Text.Json.Serialization;

namespace WebAPI.Models
{

    public enum Regions
    {
        Norte,
        Nordeste,
        Sudeste,
        Centro_Oeste,
        Sul
    }
    public class Seller
    {

        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Regions Region{ get; set; }
    }
}
