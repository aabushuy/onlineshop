using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop.Models
{
	public class CatalogItemModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int CategoryId { get; set; }

		public string Category => Categories
			.Where(c => c.Value == CategoryId.ToString())
			.FirstOrDefault()?.Text ?? string.Empty;

		public bool IsCreation => Id < 1;

		public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
	}
}
