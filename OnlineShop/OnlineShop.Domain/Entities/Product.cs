using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
	public class Product : EntityBase
	{
		public int CategoryId { get; set; }

		public int ManufacturerId { get; set; }

		public string Description { get; set; }
	}
}