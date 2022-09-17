namespace WebAPI.Models
{
    public class Opportunity
    {
        public string Id { get; set; }

        public string CNPJ { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public Seller Veller { get; set; }
    }
}
