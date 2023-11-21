using Microsoft.AspNetCore.Mvc;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.Services;
using Zamiux.Web.Entities.User;
using Zamiux.Web.ViewModels.Service;
using Zamiux.Web.ViewModels.User;

namespace Zamiux.Web.Areas.Admin.Controllers
{
    public class UserServiceController : AdminBsseController
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public UserServiceController(ZamiuxDbContext context)
        {
                _context = context;
        }
        #endregion

        #region List User Services
        public IActionResult Index()
        {
            ListServiceViewModel listService = new ListServiceViewModel()
            {
                ListServices = _context.UserServices.ToList()
            };
            return View(listService);
        }
        #endregion

        #region Create User Service
        [HttpGet]
        public IActionResult Create_User_Service()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_User_Service(CreateUserSevicesViewModel createUserSevices)
        {
            if (ModelState.IsValid)
            {
                //create instance of Model anf Fill with ViewModel
                UserService uService = new UserService()
                {
                    ServiceTitle = createUserSevices.ServiceTitle,
                    ServiceDescription = createUserSevices.ServiceDescription,
                    ServiceIcon = createUserSevices.ServiceIcon,
                    isActive = createUserSevices.isActive
                };

                //Save Data To Model
                _context.UserServices.Add(uService);

                //Save Data To DB
                _context.SaveChanges();

                return RedirectToAction("Index", "UserService");
            }
            return View(createUserSevices);
        }
        #endregion
    }
}
