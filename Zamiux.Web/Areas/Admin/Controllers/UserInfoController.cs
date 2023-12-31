﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.Ability;
using Zamiux.Web.Entities.Social;
using Zamiux.Web.Entities.User;
using Zamiux.Web.Utils;
using Zamiux.Web.Utils.ImageHandler;
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

                //create instance of model  
                var UserContent_Data = new UserContent();

                // get data from model
                UserContent_Data = _context.userContents.FirstOrDefault(x => x.Id == 1);
      
                string ImageProfile;
                string ImageBackground;               

                if (updateUserContent.ImageProfileUrl != null)
                {
                    #region upload profile image

                    ImageProfile = Guid.NewGuid().ToString("N") + Path.GetExtension(updateUserContent.ImageProfileUrl.FileName);
                    updateUserContent.ImageProfileUrl.AddImageToServer(ImageProfile, PathExtension.UserProfileContentServer, 100, 100, PathExtension.UserProfileContentServerThumb, UserContent_Data.UserImageProfileUrl);

                    #endregion
                }
                else
                {
                    ImageProfile = UserContent_Data.UserImageProfileUrl;
                }

                if (updateUserContent.ImageBackgroundUrl != null)
                {
                    #region upload background image
                    ImageBackground = Guid.NewGuid().ToString("N") + Path.GetExtension(updateUserContent.ImageBackgroundUrl.FileName);
                    updateUserContent.ImageBackgroundUrl.AddImageToServer(ImageBackground, PathExtension.UserBackgroundContentServer, 100, 100, PathExtension.UserBackgroundContentServerThumb, UserContent_Data.UserImageBackgroundUrl);
                    #endregion
                }
                else
                {
                    ImageBackground = UserContent_Data.UserImageBackgroundUrl;
                }

                //update model from viewmodel
                UserContent_Data.FullName = updateUserContent.FullName;
                UserContent_Data.UserDescription = updateUserContent.UserDescription;
                UserContent_Data.UserImageProfileUrl = ImageProfile;
                UserContent_Data.UserImageBackgroundUrl = ImageBackground;

                //save new data to model and DB
                _context.userContents.Update(UserContent_Data);
                _context.SaveChanges();

                return RedirectToAction("Index","Home");

            }
            return View();
        }
        #endregion

        #region User Intro

        #region User Intro List
        public IActionResult User_Intro(FilterUserIntroViewModel filterUserIntro)
        {
            //fetch all withoute data
            var QueryUserIntro = _context.userIntros.AsQueryable();

            //filter one; yani agar user filter Title ro mohakhas karde bood
            if (!string.IsNullOrEmpty(filterUserIntro.IntroTitle))
            {
                QueryUserIntro = QueryUserIntro.Where(x => EF.Functions.Like(x.IntroTitle, $"%{filterUserIntro.IntroTitle}%"));
            }

            // Pagging shod
            filterUserIntro.SetPagging(QueryUserIntro);

            return View(filterUserIntro);
            //ListUserIntroViewModel listUserIntro = new ListUserIntroViewModel()
            //{
            //    userIntros = _context.userIntros.ToList()
            //};
            //return View(listUserIntro);
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
                UserIntro intro = new UserIntro()
                {
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

        #region Edit User Intro
        [HttpGet]
        public IActionResult Edit_User_Intro(int id)
        {
            //get data by id
            var userintro = _context.userIntros.SingleOrDefault(x => x.Id == id);
            if (userintro == null) return NotFound();

            //new instance of VM and fill with value got Model and show in View
            var editUserIntro = new EditUserIntroViewModel()
            {
                IntroTitle = userintro.IntroTitle,
                isActive = userintro.isActive
            };

            return View(editUserIntro);
        }

        [HttpPost]
        public IActionResult Edit_User_Intro(int id,EditUserIntroViewModel editUserIntro)
        {
            //get data by id
            var userintro = _context.userIntros.SingleOrDefault(x => x.Id == id);
            if (userintro == null) return NotFound();

            //fill with value got VM and show in View and Save in Model, DB
            if (ModelState.IsValid)
            {
                userintro.IntroTitle = editUserIntro.IntroTitle;
                userintro.isActive = editUserIntro.isActive;

                _context.Update(userintro);
                _context.SaveChanges(); 
                
                return RedirectToAction("User_Intro","UserInfo");
            }

            return View(editUserIntro);
        }
        #endregion

        #region Delete User Intro

        public IActionResult Delete_User_Intro(int id)
        {
            //get data by id
            var userintro = _context.userIntros.SingleOrDefault(x => x.Id == id);
            if (userintro == null) return new JsonResult(new { status = "not-f ound" });

            //delete image if record is pic or file exists

            // delte record 
            _context.userIntros.Remove(userintro);
            _context.SaveChanges();

            return new JsonResult(new {
                status = "success"
            });
        }

        #endregion

        #endregion

        #region User Ability

        #region User Ability List
        public IActionResult User_Ability(FilterUserAbilityViewModel filterUserAbility)
        {
            //var UserAbility = _context.userAbilities.OrderByDescending(x => x.AbilityPriority).ToList(); 
            var QueryUserAbility = _context.userAbilities.AsQueryable();

            //filter one; yani agar user filter Title ro mohakhas karde bood
            if (!string.IsNullOrEmpty(filterUserAbility.AbilityTitle))
            {
                QueryUserAbility = QueryUserAbility.Where(x => EF.Functions.Like(x.AbilityTitle, $"%{filterUserAbility.AbilityTitle}%"));
            }

            //filter two; contain konde va jaigozinesh in shod 
            if (filterUserAbility.AbilityPercent != null)
            {
                QueryUserAbility = QueryUserAbility.Where(x => EF.Functions.Like(x.AbilityPercent.ToString(), $"%{filterUserAbility.AbilityPercent}%"));
            }

            //filter three
            if (filterUserAbility.AbilityPriority != null)
            {
                QueryUserAbility = QueryUserAbility.Where(x => EF.Functions.Like(x.AbilityPriority.ToString(), $"%{filterUserAbility.AbilityPriority}%"));
            }

            // Pagging shod
            filterUserAbility.SetPagging(QueryUserAbility);

            //filterUserAbility.ListEntities = (List<UserAbility>)QueryUserAbility.OrderByDescending(x=>x.Id).ToList();

            //ListUserAbilityViewModel listUserAbility = new ListUserAbilityViewModel()
            //{
            //    userAbilities = (List<UserAbility>)QueryUserAbility
            //};
            return View(filterUserAbility); 
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

        #region Delete User Ability
        [HttpGet]
        public IActionResult Edit_User_Ability(int id)
        {
            //get data by id
            var userability = _context.userAbilities.SingleOrDefault(x => x.Id == id);
            if (userability == null) return NotFound();

            //new instance of VM and fill with value got Model and show in View
            var editUserAbility = new EditUserAbilityViewModel()
            {
                AbilityTitle = userability.AbilityTitle,
                AbilityPercent = userability.AbilityPercent,
                AbilityPriority = userability.AbilityPriority,
                isActive = userability.isActive
            };

            return View(editUserAbility);
        }

        [HttpPost]
        public IActionResult Edit_User_Ability(int id,EditUserAbilityViewModel editUserAbility)
        {
            //get data by id
            var userAbility = _context.userAbilities.SingleOrDefault(x => x.Id == id);
            if (userAbility == null) return NotFound();

            //fill with value got VM and show in View and Save in Model, DB
            if (ModelState.IsValid)
            {
                userAbility.AbilityTitle = editUserAbility.AbilityTitle;
                userAbility.AbilityPercent = editUserAbility.AbilityPercent;
                userAbility.AbilityPriority = editUserAbility.AbilityPriority;
                userAbility.isActive = editUserAbility.isActive;

                _context.Update(userAbility);
                _context.SaveChanges();

                return RedirectToAction("User_Ability", "UserInfo");
            }
            return View(editUserAbility);
        }
        #endregion

        #region Delete User Ability
        public IActionResult Delete_User_Ability(int id)
        {
            //get data by id
            var ablity = _context.userAbilities.SingleOrDefault(x => x.Id == id);
            if (ablity == null) return new JsonResult(new { status = "not-found" });

            //delete image if record is pic or file exists

            // delte record 
            _context.userAbilities.Remove(ablity);
            _context.SaveChanges();

            return new JsonResult(new { 
                status = "success"
            });
        }
        #endregion

        #endregion

        #region User Social

        #region User Social List
        public IActionResult User_Social(FilterUserSocialViewModel filterUserSocial)
        {
            //ListUserSocialViewModel SocialList = new ListUserSocialViewModel()
            //{
            //    getSocials = _context.UserSocials.ToList()
            //};
            //return View(SocialList);

            //fetch all withoute data
            var QueryUserSocial = _context.UserSocials.AsQueryable();

            //filter one; yani agar user filter Title ro mohakhas karde bood
            if (!string.IsNullOrEmpty(filterUserSocial.SocialTitle))
            {
                QueryUserSocial = QueryUserSocial.Where(x => EF.Functions.Like(x.SocialTitle, $"%{filterUserSocial.SocialTitle}%"));
            }

            // Pagging shod
            filterUserSocial.SetPagging(QueryUserSocial);

            return View(filterUserSocial);
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

        #region Edit User Social
        [HttpGet]
        public IActionResult Edit_User_Social(int id)
        {
            //get usr social
            var user_social = _context.UserSocials.SingleOrDefault(s => s.Id == id);
            if (user_social == null) return NotFound();

            //new instance of VM and fill with value got Model and show in View
            var editUserSocial = new EditUserSocialViewModel()
            {
                SocialTitle = user_social.SocialTitle,
                SocialIcon = user_social.SocialIcon,
                SocialLink = user_social.SocialLink,
                isActive = user_social.isActive
            };

            return View(editUserSocial);
        }

        [HttpPost]
        public IActionResult Edit_User_Social(EditUserSocialViewModel editUserSocial, int id)
        {
            if (ModelState.IsValid)
            {
                //get usr social
                var user_social = _context.UserSocials.SingleOrDefault(s => s.Id == id);
                if (user_social == null) return NotFound();

                // fill and update model from view model
                user_social.SocialTitle = editUserSocial.SocialTitle;
                user_social.SocialLink = editUserSocial.SocialLink;
                user_social.SocialIcon = editUserSocial.SocialIcon;
                user_social.isActive = editUserSocial.isActive;

                // update db
                _context.UserSocials.Update(user_social);
                _context.SaveChanges();

                return RedirectToAction("User_Social","UserInfo");
            }
            return View(editUserSocial);
        }
        #endregion

        #region ِDelete User Social
        public IActionResult Delete_User_Social(int id)
        {
            //get usr social
            var user_social = _context.UserSocials.SingleOrDefault(s => s.Id == id);
            if (user_social == null) return NotFound();

            //delete image if record is pic or file exists

            // delte record 
            _context.UserSocials.Remove(user_social);
            _context.SaveChanges();

            return new JsonResult(new
            {
                status = "success"
            });
        }


        #endregion

        #endregion

    }
}
