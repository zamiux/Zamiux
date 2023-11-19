using Microsoft.AspNetCore.Mvc;

namespace Zamiux.Web.Areas.Admin.Controllers
{
	public class HomeController : AdminBsseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
