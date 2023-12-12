using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zamiux.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class AdminBsseController : Controller
	{
		
	}
}
