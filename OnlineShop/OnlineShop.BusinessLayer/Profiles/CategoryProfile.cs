using AutoMapper;
using OnlineShop.Domain.DataAccess;
using OnlineShop.Domain.Entities;

namespace OnlineShop.BusinessLayer.Profiles
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, CategoryDto>()
				.ForMember(dest =>
					dest.Parent,
					opt => opt.MapFrom(src => src.ParentId.HasValue
						? new CategoryDto() { Id = src.ParentId.Value }
						: null));
		}
	}
}
