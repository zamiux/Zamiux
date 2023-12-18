using Microsoft.AspNetCore.Mvc;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.Ability;
using Zamiux.Web.Entities.Contact;
using Zamiux.Web.Entities.Services;
using Zamiux.Web.Entities.Social;
using Zamiux.Web.Entities.User;
using Zamiux.Web.Entities.Works;
using Zamiux.Web.Migrations;
using Zamiux.Web.ViewModels.Home;

namespace Zamiux.Web.ViewComponents
{
    
    #region Menu
    public class MenuHeaderViewComponent : ViewComponent
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public MenuHeaderViewComponent(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<InfoContact> infos = new List<InfoContact>();
            infos = _context.InfoContacts.Where(m => m.Id == 1).ToList();

            SiteHeaderViewModel siteHeader = new SiteHeaderViewModel() {
                ContactLogo = infos[0].ContactLogo,
                ContactLogoDark = infos[0].ContactLogoDark
            };
            
            return View("MenuHeader", siteHeader);
        }
    }
    #endregion

    #region Slider
    public class SliderViewComponent : ViewComponent
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public SliderViewComponent(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<UserContent> usernameContent = new List<UserContent>();
            usernameContent = _context.userContents.Where(x => x.Id == 1).ToList();

            SliderViewModel sliderViewModel = new SliderViewModel
            {
                Fullname = usernameContent[0].FullName,
                intros = _context.userIntros.Where(x=>x.isActive == true).ToList(),
                UserBackground = usernameContent[0].UserImageBackgroundUrl
            };

            return View("Slider", sliderViewModel);
        }
    }
    #endregion

    #region FooterSocial
    public class FooterSocialViewComponent : ViewComponent
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public FooterSocialViewComponent(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<InfoContact> US = new List<InfoContact>();
            US = _context.InfoContacts.Where(c => c.Id == 1).ToList();

            ContactHomeViewModel contactHome = new ContactHomeViewModel()
            {
                ContactAddress = US[0].ContactAddress,
                ContactEmailOne = US[0].ContactEmailOne,
                ContactEmailTwo = US[0].ContactEmailTwo,
                ContactPhone = US[0].ContactPhone,
                socials = _context.UserSocials.Where(x => x.isActive == true).ToList()
            };

            return View("FooterSocial", contactHome);
        }
    }
    #endregion

    #region Hero
    public class HeroViewComponent : ViewComponent
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public HeroViewComponent(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userInfo = _context.userContents.Where(u => u.Id == 1).ToList();
            var userIntos_data = _context.userIntros.ToList();

            HeroViewModel hero = new HeroViewModel {
                UserDesc = userInfo[0].UserDescription,
                UserProfilePic = userInfo[0].UserImageProfileUrl,
                userIntros = userIntos_data
            };

            return View("Hero", hero);
        }
    }
    #endregion

    #region Skill
    public class SkillViewComponent : ViewComponent
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public SkillViewComponent(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<UserAbility> userAbilities = new List<UserAbility>();
            userAbilities = _context.userAbilities.Where(x => x.isActive == true).ToList();

            SkillViewModel skills = new SkillViewModel() {
                Abilities = userAbilities
            };
            return View("Skill", skills);
        }
    }
    #endregion

    #region Services
    public class ServicesUsViewComponent : ViewComponent
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public ServicesUsViewComponent(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<UserService> myServices = new List<UserService>();
            myServices = _context.UserServices.Where(x=>x.isActive == true).ToList();

            ServicesUSViewModel servicesUS = new ServicesUSViewModel() {
                userServices = myServices
            };

            return View("ServicesUs", servicesUS);
        }
    }
    #endregion

    #region Numbers
    public class NumbersViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Numbers");
        }
    }
    #endregion

    #region Works
    public class WorksViewComponent : ViewComponent
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public WorksViewComponent(ZamiuxDbContext context)
        {
            _context= context;
        }
        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Work> myWorks = new List<Work>();
            myWorks = _context.Works.Where(x => x.IsActive == true).ToList();


            List<string> ListCate = new List<string>();
            ListCate = _context.Works.Where(x => x.IsActive == true).Select(x => x.CategoryName).Distinct().ToList();

            WorkViewModel viewModel = new WorkViewModel()
            {
                ListWorks = myWorks,
                categoryWork = ListCate
            };

            
            return View("Works", viewModel);
        }
    }
    #endregion

    #region Testimonials
    public class TestimonialsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Testimonials");
        }
    }
    #endregion

    #region BlogSlide
    public class BlogSlideViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("BlogSlide");
        }
    }
    #endregion

    #region ContactInfo
    public class ContactInfoViewComponent : ViewComponent
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public ContactInfoViewComponent(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<InfoContact> US = new List<InfoContact>();
            US = _context.InfoContacts.Where(c => c.Id == 1).ToList();

            ContactHomeViewModel contactHome = new ContactHomeViewModel() {
                ContactAddress = US[0].ContactAddress,
                ContactEmailOne = US[0].ContactEmailOne,
                ContactEmailTwo = US[0].ContactEmailTwo,
                ContactPhone = US[0].ContactPhone,
                socials = _context.UserSocials.Where(x => x.isActive == true).ToList()
            };
            return View("ContactInfo", contactHome);
        }
    }
	#endregion

	#region Last Blog
	public class LastBlogViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("LastBlog");
		}
	}
	#endregion

	#region Last Comment
	public class LastCommentViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("LastComment");
		}
	}
	#endregion

	#region Blog Category
	public class BlogCategoryViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("BlogCategory");
		}
	}
	#endregion
}
