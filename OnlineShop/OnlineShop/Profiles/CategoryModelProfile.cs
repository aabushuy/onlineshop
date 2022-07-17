using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Models;

namespace OnlineShop.Profiles
{
	public class CategoryModelProfile : Profile
	{
		public CategoryModelProfile()
		{
			CreateMap<Category, CatalogItemModel>()
				.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.ParentId ?? -1));

			CreateMap<Category, CatalogItemModel>()
				.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.ParentId ?? -1));

			CreateMap<CatalogItemModel, Category>()
				.ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.CategoryId));
		}
	}
}
