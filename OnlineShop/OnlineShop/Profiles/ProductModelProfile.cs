using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Models;

namespace OnlineShop.Profiles
{
	public class ProductModelProfile : Profile
	{
		public ProductModelProfile()
		{
			CreateMap<Product, CatalogItemModel>();

			CreateMap<Product, ProductDetailsModel>();

			CreateMap<ProductDetailsModel, Product>();
		}
	}
}