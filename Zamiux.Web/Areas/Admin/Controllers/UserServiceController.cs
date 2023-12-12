using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.Services;
using Zamiux.Web.Entities.User;
using Zamiux.Web.ViewModels.Service;
using Zamiux.Web.ViewModels.Social;
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
        public IActionResult Index(FilterListServiceViewModel filterListService)
        {
            //fetch all withoute data
            var QueryUserService = _context.UserServices.AsQueryable();

            //filter one; yani agar user filter Title ro mohakhas karde bood
            if (!string.IsNullOrEmpty(filterListService.ServiceTitle))
            {
                QueryUserService = QueryUserService.Where(x => EF.Functions.Like(x.ServiceTitle, $"%{filterListService.ServiceTitle}%"));
            }

            if (!string.IsNullOrEmpty(filterListService.ServiceDescription))
            {
                QueryUserService = QueryUserService.Where(x => EF.Functions.Like(x.ServiceDescription, $"%{filterListService.ServiceDescription}%"));
            }

            // Pagging shod
            filterListService.SetPagging(QueryUserService);

            return View(filterListService);
            //ListServiceViewModel listService = new ListServiceViewModel()
            //{
            //    ListServices = _context.UserServices.ToList()
            //};
            //return View(listService);
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

        #region Edit User Service
        [HttpGet]
        public IActionResult Edit_User_Service(int id)
        {
            //get usr social
            var user_service = _context.UserServices.SingleOrDefault(s => s.Id == id);
            if (user_service == null) return NotFound();

            //new instance of VM and fill with value got Model and show in View
            var editUserService = new EditUserServiceViewModel()
            {
                ServiceTitle = user_service.ServiceTitle,
                ServiceDescription = user_service.ServiceDescription,
                ServiceIcon = user_service.ServiceIcon,
                isActive = user_service.isActive
            };

            return View(editUserService);
        }

        [HttpPost]
        public IActionResult Edit_User_Service(EditUserServiceViewModel editUserService,int id)
        {
            if (ModelState.IsValid)
            {
                //get usr social
                var user_service = _context.UserServices.SingleOrDefault(s => s.Id == id);
                if (user_service == null) return NotFound();

                // fill and update model from view model
                user_service.ServiceTitle = editUserService.ServiceTitle;
                user_service.ServiceDescription = editUserService.ServiceDescription;
                user_service.ServiceIcon = editUserService.ServiceIcon;
                user_service.isActive = editUserService.isActive;

                // update db
                _context.UserServices.Update(user_service);
                _context.SaveChanges();

                return RedirectToAction("Index", "UserService");
            }
            return View(editUserService);
        }
        #endregion

        #region Delete User Service
        public IActionResult Delete_User_Service(int id)
        {
            //get usr service
            var user_service = _context.UserServices.SingleOrDefault(s => s.Id == id);
            if (user_service == null) return NotFound();

            //delete image if record is pic or file exists

            // delte record 
            _context.UserServices.Remove(user_service);
            _context.SaveChanges();

            return new JsonResult(new
            {
                status = "success"
            });
        }
        #endregion
    }
}
