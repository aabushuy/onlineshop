namespace OnlineShop.Models
{
	public class CatalogModel
	{
		public string CatalogName { get; set; }

		public List<CatalogItemModel> Items { get; set; }

		public CatalogModel()
		{
			Items = new List<CatalogItemModel>();
		}
	}
}
