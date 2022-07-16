using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Interfaces.Services;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(
			ICategoryService categoryService,
			IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		// GET: CategoryController
		public async Task<ActionResult> Index()
		{
			var categories = (await _categoryService.GetAllAsync())
				.Where(c => c.IsRoot)
				.Select(c => _mapper.Map<CategoryModel>(c));

			return View(categories);
		}

		// GET: CategoryController/Show/5
		public async Task<ActionResult> Show(int id)
		{
			var categories = (await _categoryService.GetAllAsync())
				.Where(c => c.Parent != null && c.Parent.Id == id)
				.Select(c => _mapper.Map<CategoryModel>(c))
				.ToList();

			if (categories.Count == 0)
			{
				//redirect to products and show them
			}

			return View("Index", categories);
		}

		// GET: CategoryController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: CategoryController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CategoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CategoryController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: CategoryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CategoryController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: CategoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
