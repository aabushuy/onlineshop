using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Services;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
	public abstract class CatalogControllerBase : Controller
	{
		protected readonly ICategoryService _categoryService;
		protected readonly IMapper _mapper;

		public CatalogControllerBase(IMapper mapper, ICategoryService categoryService)
		{
			_mapper = mapper;
			_categoryService = categoryService;
		}

		protected CatalogModel CreateCatalogModel(string catalogName, IEnumerable<CatalogItemModel> catalogItems)
		{
			return new CatalogModel()
			{
				CatalogName = catalogName,
				Items = catalogItems.ToList()
			};
		}

		protected void AddSelectListToModel(List<SelectListItem> target, IEnumerable<EntityBase> entities, int? selected = null)
		{
			if (target == null)
			{
				target = new List<SelectListItem>();
			}

			var listItems = entities
				.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = c.Name,
					Selected = c.Id == (selected ?? -1),
				});

			target.AddRange(listItems);
		}
	}
}
