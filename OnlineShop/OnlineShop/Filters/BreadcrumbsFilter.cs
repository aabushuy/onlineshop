using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Services;
using OnlineShop.Models;

namespace OnlineShop.Filters
{
	public class BreadcrumbsFilter : Attribute, IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			await next();

			var controller = context.Controller as Controller;
			if (controller == null || context.ActionDescriptor is not ControllerActionDescriptor controllerDescriptor)
			{
				return;
			}

			var breadcrumbService = controller.HttpContext.RequestServices.GetService(typeof(IBreadcrumbService)) as IBreadcrumbService;
			if (breadcrumbService == null)
			{
				return;
			}

			var breadcrumbs = GetCommonBreadcrumbs();
			controller.ViewData["Breadcrumbs"] = breadcrumbs;

			foreach (var breadcrumbItem in breadcrumbService.GetParentBreadcrumbs(controllerDescriptor.ControllerName, 0))
			{
				breadcrumbs.Add(new BreadcrumbModel() { Title = breadcrumbItem.name });
			}

			//ViewData["Title"] = requestedCategory?.Name;
		}

		private IList<BreadcrumbModel> GetCommonBreadcrumbs()
		{
			var breadcrumbs = new List<BreadcrumbModel>();
			breadcrumbs.Add(new BreadcrumbModel() { Title = "Home" });
			return breadcrumbs;
		}
	}
}
