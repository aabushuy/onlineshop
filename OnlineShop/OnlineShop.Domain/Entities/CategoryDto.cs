namespace OnlineShop.Domain.Entities
{
	public class CategoryDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public CategoryDto? Parent { get; set; }

		public bool IsRoot => Parent == null;
	}
}
