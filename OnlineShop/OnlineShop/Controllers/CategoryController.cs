using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Services;
using OnlineShop.Filters;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
	public class CategoryController : CatalogControllerBase
	{
		public CategoryController(IMapper mapper, ICategoryService categoryService)
			: base(mapper, categoryService)
		{
		}

		[BreadcrumbsFilter]
		// GET: CategoryController
		public async Task<ActionResult> Index()
		{
			var categories = (await _categoryService.GetAllAsync())
				.Where(c => c.IsRoot)
				.Select(c => _mapper.Map<CatalogItemModel>(c));

			return View("_CatalogPartial", CreateCatalogModel("Category", categories));
		}

		[BreadcrumbsFilter]
		// GET: CategoryController/Show/5
		public async Task<ActionResult> Show(int id)
		{
			var categories = (await _categoryService.GetAllAsync())
				.Where(c => c.ParentId.HasValue && c.ParentId.Value == id)
				.Select(c => _mapper.Map<CatalogItemModel>(c))
				.ToList();

			if (categories.Count == 0)
			{
				return RedirectToAction("Show", "Product", new { id = id });
			}

			return View("_CatalogPartial", CreateCatalogModel("Category", categories));
		}

		// GET: CategoryController/Create
		public async Task<ActionResult> Create()
		{
			var category = new CatalogItemModel();
			AddSelectListToModel(category.Categories, await _categoryService.GetAllAsync());

			return View(nameof(Edit), category);
		}

		// POST: CategoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(CatalogItemModel categoryEditModel)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var category = _mapper.Map<Category>(categoryEditModel);
				_ = await _categoryService.AddAsync(category);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CategoryController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			var requestedCategory = await _categoryService.GetAsync(id);
			if (requestedCategory == null)
			{
				return RedirectToAction(nameof(Index));
			}

			var category = _mapper.Map<CatalogItemModel>(requestedCategory);

			AddSelectListToModel(
				category.Categories,
				(await _categoryService.GetAllAsync()).Where(c => c.Id != id),
				requestedCategory.ParentId);

			return View(category);
		}

		// POST: CategoryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(CatalogItemModel categoryEditModel)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var category = _mapper.Map<Category>(categoryEditModel);
				_ = await _categoryService.UpdateAsync(category);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CategoryController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			var requestedCategory = await _categoryService.GetAsync(id);

			var category = _mapper.Map<CatalogItemModel>(requestedCategory);

			return View("_DeleteCatalogItem", category);
		}

		// POST: CategoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(CatalogItemModel categoryEditModel)
		{
			try
			{
				var category = _mapper.Map<Category>(categoryEditModel);
				await _categoryService.DeleteAsync(category);

				if (categoryEditModel.CategoryId > 0)
				{
					return RedirectToAction(nameof(Show), new { id = categoryEditModel.CategoryId });
				}

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View("_DeleteCatalogItem", categoryEditModel);
			}
		}
	}
}
