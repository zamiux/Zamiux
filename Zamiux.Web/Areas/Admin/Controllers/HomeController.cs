using Microsoft.AspNetCore.Mvc;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.Contact;
using Zamiux.Web.Entities.User;
using Zamiux.Web.ViewModels.Contact;

namespace Zamiux.Web.Areas.Admin.Controllers
{
	public class HomeController : AdminBsseController
	{
        #region Ctor
        private ZamiuxDbContext _context;
        public HomeController(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion
        public IActionResult Index()
		{
			return View();
		}

		#region Site Setting
		[HttpGet]
		public IActionResult sitesetting()
		{
            //get data from model
            List<InfoContact> contacts = new List<InfoContact>();
            contacts = _context.InfoContacts.Where(x => x.Id == 1).ToList();

            ViewBag.getContactPhone = contacts[0].ContactPhone;
            ViewBag.getContactAddress = contacts[0].ContactAddress;
            ViewBag.getContactEmailOne = contacts[0].ContactEmailOne;
            ViewBag.getContactEmailTwo = contacts[0].ContactEmailTwo;
            ViewBag.getContactLogo = contacts[0].ContactLogo;
            ViewBag.getContactLogoDark = contacts[0].ContactLogoDark;

            return View();
        }

        [HttpPost]
        public IActionResult sitesetting(UpdateInfoContactViewModel updateInfo)
        {
            if (ModelState.IsValid)
            {               
                //create instance of model  
                var InfoContact_Data = new InfoContact();

                // get data from model
                InfoContact_Data = _context.InfoContacts.FirstOrDefault(x => x.Id == 1);

                //update model from viewmodel
                InfoContact_Data.ContactPhone = updateInfo.ContactPhone;
                InfoContact_Data.ContactAddress = updateInfo.ContactAddress;
                InfoContact_Data.ContactEmailOne = updateInfo.ContactEmailOne;
                InfoContact_Data.ContactEmailTwo = updateInfo.ContactEmailTwo;
                InfoContact_Data.ContactLogoDark = updateInfo.ContactLogoDark;
                InfoContact_Data.ContactLogo = updateInfo.ContactLogo;

                //save new data to model and DB
                _context.InfoContacts.Update(InfoContact_Data);
                _context.SaveChanges();

                return RedirectToAction("SiteSetting", "Home");

            }
            return View();
        }
        #endregion
    }
}
