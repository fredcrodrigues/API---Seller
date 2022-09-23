namespace WebAPI.Models
{
    public class Opportunity
    {
        public string? Id { get; set; } = null!;

        public CNPJ Cnpj { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Value { get; set; }

        public Seller Seller { get; set; } = null!;
    }
}
