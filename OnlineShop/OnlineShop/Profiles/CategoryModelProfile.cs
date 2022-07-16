using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Models;

namespace OnlineShop.Profiles
{
	public class CategoryModelProfile : Profile
	{
		public CategoryModelProfile()
		{
			CreateMap<CategoryDto, CategoryModel>();
		}
	}
}
