using System.ComponentModel.DataAnnotations.Schema;

namespace WyseyeCase.Models.Model
{
	public class Car
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public string LicensePlate { get; set; }
	}
}
