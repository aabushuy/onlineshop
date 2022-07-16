using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces.Services
{
	public interface IBreadcrumbService
	{
		IList<(string name, string id)> GetParentBreadcrumbs(string name, int id);
	}
}
