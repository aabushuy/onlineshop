using OnlineShop.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.Services
{
	public class BreadcrumbService : IBreadcrumbService
	{
		public IList<(string name, string id)> GetParentBreadcrumbs(string name, int id)
		{
			var result = new List<(string name, string id)>();

			return result;
		}
	}
}
