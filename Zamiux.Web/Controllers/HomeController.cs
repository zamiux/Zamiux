using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.Contact;
using Zamiux.Web.ViewModels.Contact;

namespace Zamiux.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public HomeController(ZamiuxDbContext context)
        {
                _context = context;
        }
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendContactMsgViewModel SendContactMsg)
        {
            if (ModelState.IsValid)
            {
                ContactMsg msg = new ContactMsg() { 
                    Fullname= SendContactMsg.Fullname,
                    UserEmail= SendContactMsg.UserEmail,
                    UserMessage= SendContactMsg.UserMessage,
                    UserSubject = SendContactMsg.UserSubject
                };

                _context.ContactMsgs.Add(msg);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(SendContactMsg);
        }


    }
}