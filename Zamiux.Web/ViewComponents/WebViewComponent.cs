using Microsoft.AspNetCore.Mvc;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.Ability;
using Zamiux.Web.Entities.User;
using Zamiux.Web.ViewModels.Home;

namespace Zamiux.Web.ViewComponents
{
    
    #region Menu
    public class MenuHeaderViewComponent : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("MenuHeader");
        }
    }
    #endregion

    #region LogoHeader
    public class LogoHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LogoHeader");
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("FooterSocial");
        }
    }
    #endregion

    #region Hero
    public class HeroViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Hero");
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("ServicesUs");
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Works");
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("ContactInfo");
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
