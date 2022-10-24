using System.ComponentModel.DataAnnotations;
namespace SalesDB.shared.Models
{
	public class CNPJ
	{
		
		public string? Number { get; set; } = null!;

		public string? Social_reason { get; set; } = null!;

		public string? State { get; set; } = null!;

		public string? Activity { get; set; } = null!;

	}
}
