using Zamiux.Web.Entities.User;

namespace Zamiux.Web.ViewModels.Home
{
    public class HeroViewModel
    {
        public List<UserIntro>? userIntros { get; set; } = new List<UserIntro> { };
        public string? UserDesc { get; set; }
        public string? UserProfilePic { get; set; }
    }
}
