namespace OnlineShop.Models
{
	public class CategoryModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int? ParentId { get; set; }
	}
}
