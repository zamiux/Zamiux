using Microsoft.AspNetCore.Mvc;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.Contact;
using Zamiux.Web.Entities.User;
using Zamiux.Web.Utils;
using Zamiux.Web.Utils.ImageHandler;
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
            ViewBag.ResumeCount = _context.resumeDls.Count();
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

                #region Old Images Loaded
                string ImageLogo = updateInfo.ContactLogo_old;
                string ImageLogoDark = updateInfo.ContactLogoDark_old;
                #endregion

                #region Upload Logo
                ImageLogo = Guid.NewGuid().ToString("N") + Path.GetExtension(updateInfo.ImageContactLogo.FileName);
                updateInfo.ImageContactLogo.AddImageToServer(ImageLogo, PathExtension.logoContentServer, 100, 100, PathExtension.logoContentServerThumb, InfoContact_Data.ContactLogo);

                #endregion

                #region Upload Logo Dark
                ImageLogoDark = Guid.NewGuid().ToString("N") + Path.GetExtension(updateInfo.ImageContactLogoDark.FileName);
                updateInfo.ImageContactLogoDark.AddImageToServer(ImageLogoDark, PathExtension.logoContentServerDark, 100, 100, PathExtension.logoContentServerDarkThumb, InfoContact_Data.ContactLogoDark);

                #endregion


                //update model from viewmodel
                InfoContact_Data.ContactPhone = updateInfo.ContactPhone;
                InfoContact_Data.ContactAddress = updateInfo.ContactAddress;
                InfoContact_Data.ContactEmailOne = updateInfo.ContactEmailOne;
                InfoContact_Data.ContactEmailTwo = updateInfo.ContactEmailTwo;
                InfoContact_Data.ContactLogoDark = ImageLogoDark;
                InfoContact_Data.ContactLogo = ImageLogo;

                //save new data to model and DB
                _context.InfoContacts.Update(InfoContact_Data);
                _context.SaveChanges();

                return RedirectToAction("SiteSetting", "Home");

            }
            return View();
        }
        #endregion

        #region Contact Message
        public IActionResult Contact_Message(ListContactMsgViewModel listContact)
        {
            var QueryUserMessage = _context.ContactMsgs.AsQueryable();
            // Pagging shod
            listContact.SetPagging(QueryUserMessage);

            return View(listContact);
        }

        public IActionResult Delete_Message(int id)
        {
            //get msg
            var user_message = _context.ContactMsgs.SingleOrDefault(s => s.Id == id);
            if (user_message == null) return NotFound();

            //delete image if record is pic or file exists

            // delte record 
            _context.ContactMsgs.Remove(user_message);
            _context.SaveChanges();

            return new JsonResult(new
            {
                status = "success"
            });
        }
        #endregion
    }
}
