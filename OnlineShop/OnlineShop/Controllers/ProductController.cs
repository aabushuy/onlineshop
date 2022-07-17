using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Services;
using OnlineShop.Filters;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
	public class ProductController : CatalogControllerBase
	{
		private readonly IProductService _productService;
		private readonly IManufacturerService _manufacturerService;
		private readonly IProductStockService _productStockService;

		public ProductController(
			IMapper mapper,
			ICategoryService categoryService,
			IProductService productService,
			IManufacturerService manufacturerService,
			IProductStockService productStockService)
			: base(mapper, categoryService)
		{
			_productService = productService;
			_manufacturerService = manufacturerService;
			_productStockService = productStockService;
		}

		/// <summary>
		/// GET: ProductsController
		/// </summary>
		/// <param name="id">Category Id.</param>
		/// <returns></returns>
		[BreadcrumbsFilter]
		public async Task<ActionResult> Show(int id)
		{
			var products = (await _productService.GetAllAsync())
				.Where(x => x.CategoryId == id)
				.Select(p => _mapper.Map<CatalogItemModel>(p))
				.ToList();

			if (products.Count == 0)
			{
				// probably it's a product
				return RedirectToAction(nameof(Index), new { id = id });
			}

			return View("_CatalogPartial", CreateCatalogModel("Product", products));
		}

		[BreadcrumbsFilter]
		public async Task<ActionResult> Index(int? id)
		{
			if (id.HasValue)
			{
				var product = await _productService.GetAsync(id.Value);
				if (product == null)
				{
					return View("_CatalogPartial", CreateCatalogModel("Product", new List<CatalogItemModel>()));
				}

				var productView = _mapper.Map<ProductDetailsModel>(product);
				
				await EnrichProductDetailsModelAsync(productView);

				return View("Details", productView);
			}

			var products = (await _productService.GetAllAsync())
				.Select(p => _mapper.Map<CatalogItemModel>(p));

			return View("_CatalogPartial", CreateCatalogModel("Product", products));
		}

		// GET: ProductsController/Create
		public async Task<ActionResult> Create()
		{
			var product = new ProductDetailsModel();

			await EnrichProductDetailsModelAsync(product);

			return View(nameof(Edit), product);
		}

		// POST: ProductsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(ProductDetailsModel productDetailsModel)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var product = _mapper.Map<Product>(productDetailsModel);
				_ = await _productService.AddAsync(product);

				var productStock = new ProductStock()
				{
					ProductId = product.Id,
					PricePerUnit = productDetailsModel.PricePerUnit,
					StockQuantity = productDetailsModel.StockQuantity
				};

				_ = await _productStockService.AddAsync(productStock);

				return RedirectToAction(nameof(Show), new { id = productDetailsModel.CategoryId });
			}
			catch
			{
				return View();
			}
		}

		// GET: ProductsController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			var requestedProduct = await _productService.GetAsync(id);

			var product = _mapper.Map<ProductDetailsModel>(requestedProduct);

			await EnrichProductDetailsModelAsync(product);

			return View(product);
		}

		// POST: ProductsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(ProductDetailsModel productDetailsModel)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var product = _mapper.Map<Product>(productDetailsModel);
				_ = await _productService.UpdateAsync(product);

				var productStock = await _productStockService.GetAsync(product.Id);
				if (productStock != null)
				{
					productStock.PricePerUnit = productDetailsModel.PricePerUnit;
					productStock.StockQuantity = productDetailsModel.StockQuantity;

					_ = await _productStockService.UpdateAsync(productStock);
				}
				else 
				{
					productStock = new ProductStock()
					{
						ProductId = product.Id,
						PricePerUnit = productDetailsModel.PricePerUnit,
						StockQuantity = productDetailsModel.StockQuantity
					};

					_ = await _productStockService.AddAsync(productStock);
				}

				return RedirectToAction(nameof(Show), new { id = productDetailsModel.CategoryId });
			}
			catch
			{
				return View();
			}
		}

		// GET: ProductsController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			var requestedProduct = await _productService.GetAsync(id);

			var product = _mapper.Map<CatalogItemModel>(requestedProduct);

			return View("_DeleteCatalogItem", product);
		}

		// POST: ProductsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(CatalogItemModel productDetailsModel)
		{
			try
			{
				var product = _mapper.Map<Product>(productDetailsModel);
				await _productService.DeleteAsync(product);
				
				var productStock = await _productStockService.GetAsync(product.Id);
				if (productStock != null)
				{
					await _productStockService.DeleteAsync(productStock);
				}

				if (productDetailsModel.CategoryId > 0)
				{
					return RedirectToAction(nameof(Show), new { id = productDetailsModel.CategoryId });
				}

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View("_DeleteCatalogItem", productDetailsModel);
			}
		}

		private async Task EnrichProductDetailsModelAsync(ProductDetailsModel model)
		{
			AddSelectListToModel(
					model.Categories,
					await _categoryService.GetAllAsync(),
					selected: model.CategoryId);

			AddSelectListToModel(
				model.Manufacturers,
				await _manufacturerService.GetAllAsync(),
				selected: model.ManufacturerId);

			var productStock = await _productStockService.GetAsync(model.Id) ?? new ProductStock();

			model.PricePerUnit = productStock.PricePerUnit;
			model.StockQuantity = productStock.StockQuantity;
		}
	}
}
