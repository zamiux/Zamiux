using Microsoft.AspNetCore.Mvc;
using Zamiux.Web.Context;

namespace Zamiux.Web.Areas.Admin.Controllers
{
    public class UserInfoController : AdminBsseController
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public UserInfoController(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion

        #region User Content
        [HttpGet]
        public IActionResult UserContent()
        {
            return View();
        }
        #endregion
    }
}
