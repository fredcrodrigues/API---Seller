using System.Text.Json.Serialization;

namespace WebAPI.Models
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

        public string? Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

      
        public Regions Region{ get; set; }
    }
}
