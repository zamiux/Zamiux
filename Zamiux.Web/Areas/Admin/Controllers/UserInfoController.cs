using Microsoft.AspNetCore.Mvc;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.Ability;
using Zamiux.Web.Entities.Social;
using Zamiux.Web.Entities.User;
using Zamiux.Web.ViewModels.Ability;
using Zamiux.Web.ViewModels.Social;
using Zamiux.Web.ViewModels.User;

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
            //get data from model
            List<UserContent> contents = new List<UserContent>();
            contents = _context.userContents.Where(x => x.Id == 1).ToList();

            ViewBag.getFullName = contents[0].FullName;
            ViewBag.getUserDescription = contents[0].UserDescription;
            ViewBag.getUserImageProfileUrl = contents[0].UserImageProfileUrl;
            ViewBag.getUserImageBackgroundUrl = contents[0].UserImageBackgroundUrl;

            return View();
        }

        [HttpPost]
        public IActionResult UserContent(UpdateUserContentViewModel updateUserContent)
        {
            if (ModelState.IsValid)
            {
                if (updateUserContent.UserImageProfileUrl is null)
                {
                    updateUserContent.UserImageProfileUrl = "hero.jpg";
                }

                if (updateUserContent.UserImageBackgroundUrl is null)
                {
                    updateUserContent.UserImageBackgroundUrl = "backprofile.jpg";
                }
                //create instance of model  
                var UserContent_Data = new UserContent();

                // get data from model
                UserContent_Data = _context.userContents.FirstOrDefault(x => x.Id == 1);

                //update model from viewmodel
                UserContent_Data.FullName = updateUserContent.FullName;
                UserContent_Data.UserDescription = updateUserContent.UserDescription;
                UserContent_Data.UserImageProfileUrl = updateUserContent.UserImageProfileUrl;
                UserContent_Data.UserImageBackgroundUrl = updateUserContent.UserImageBackgroundUrl;

                //save new data to model and DB
                _context.userContents.Update(UserContent_Data);
                _context.SaveChanges();

                return RedirectToAction("Index","Home");

            }
            return View();
        }
        #endregion

        #region User Intro List
        public IActionResult User_Intro()
        {
            ListUserIntroViewModel listUserIntro = new ListUserIntroViewModel()
            {
                userIntros = _context.userIntros.ToList()
            };
            return View(listUserIntro);
        }
        #endregion

        #region Create User Intro
        [HttpGet]
        public IActionResult Create_User_Intro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_User_Intro(CreateUserIntroViewModel createUserIntro)
        {
            if (ModelState.IsValid)
            {
                //create instance of Model anf Fill with ViewModel
                UserIntro intro = new UserIntro() {
                    IntroTitle = createUserIntro.IntroTitle,
                    isActive = createUserIntro.isActive
                };

                //Save Data To Model
                _context.userIntros.Add(intro);

                //Save Data To DB
                _context.SaveChanges();

                return RedirectToAction("User_Intro", "UserInfo");
            }
            return View(createUserIntro);
        }
        #endregion

        #region User Ability List
        public IActionResult User_Ability()
        {
            ListUserAbilityViewModel listUserAbility = new ListUserAbilityViewModel()
            {
                userAbilities = _context.userAbilities.ToList()
            };
            return View(listUserAbility);
        }
        #endregion

        #region Create User Ability
        [HttpGet]
        public IActionResult Create_User_Ability()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_User_Ability(CreateUserAbilityViewModel createUserAbility)
        {
            if (ModelState.IsValid)
            {
                //create instance of Model anf Fill with ViewModel
                UserAbility userAbility_data = new UserAbility()
                {
                    AbilityTitle = createUserAbility.AbilityTitle,
                    AbilityPercent = createUserAbility.AbilityPercent,
                    AbilityPriority = createUserAbility.AbilityPriority,
                    isActive = createUserAbility.isActive
                };

                //Save Data To Model
                _context.userAbilities.Add(userAbility_data);

                //Save Data To DB
                _context.SaveChanges();

                return RedirectToAction("User_Ability", "UserInfo");
            }
            return View(createUserAbility);
        }
        #endregion

        #region User Social List
        public IActionResult User_Social()
        {
            ListUserSocialViewModel SocialList = new ListUserSocialViewModel()
            {
                getSocials = _context.UserSocials.ToList()
            };
            return View(SocialList);
        }
        #endregion

        #region Create User Social
        [HttpGet]
        public IActionResult Create_User_Social()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_User_Social(CreateUserSocialViewModel createUserSocial)
        {
            if (ModelState.IsValid)
            {
                //create instance of Model anf Fill with ViewModel
                UserSocial UserSocial_Data = new UserSocial()
                {
                    SocialTitle = createUserSocial.SocialTitle,
                    SocialIcon = createUserSocial.SocialIcon,
                    SocialLink = createUserSocial.SocialLink,
                    isActive = createUserSocial.isActive
                };

                //Save Data To Model
                _context.UserSocials.Add(UserSocial_Data);

                //Save Data To DB
                _context.SaveChanges();

                return RedirectToAction("User_Social", "UserInfo");
            }
            return View(createUserSocial);
        }
        #endregion
    }
}
