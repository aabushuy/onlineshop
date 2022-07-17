using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop.Models
{
	public class ProductDetailsModel : CatalogItemModel
	{
		public int ManufacturerId { get; set; }

		public string Manufacturer => Manufacturers
			.Where(c => c.Value == ManufacturerId.ToString())
			.FirstOrDefault()?.Text ?? string.Empty;

		public string Description { get; set; }

		public decimal PricePerUnit { get; set; }

		public int StockQuantity { get; set; }

		public List<SelectListItem> Manufacturers { get; set; } = new List<SelectListItem>();
	}
}