using Microsoft.AspNetCore.Mvc;

namespace Zamiux.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

       
    }
}
