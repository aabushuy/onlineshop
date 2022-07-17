namespace OnlineShop.Domain.Entities
{
	public class ProductStock
	{
		public int Id { get; set; }

		public int ProductId { get; set; }

		public decimal PricePerUnit { get; set; }

		public int StockQuantity { get; set; }
	}
}
