using Zamiux.Web.Entities.User;

namespace Zamiux.Web.ViewModels.Home
{
    public class SliderViewModel
    {
        public string? Fullname { get; set; }
        public List<UserIntro> intros { get; set; }
        public string? UserBackground { get; set; }
    }
}
