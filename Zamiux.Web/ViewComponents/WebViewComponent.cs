using Microsoft.AspNetCore.Mvc;

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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Slider");
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Skill");
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
