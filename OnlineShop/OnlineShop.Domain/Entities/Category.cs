using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
	public class Category : EntityBase
	{
		public int? ParentId { get; set; }

		[NotMapped]
		public bool IsRoot => !ParentId.HasValue;
	}
}
