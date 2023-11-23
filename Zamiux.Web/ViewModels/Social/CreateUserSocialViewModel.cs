namespace Zamiux.Web.ViewModels.Social
{
    public class CreateUserSocialViewModel
    {
        public string? SocialTitle { get; set; }
        public string? SocialIcon { get; set; }
        public string? SocialLink { get; set; }
        public bool isActive { get; set; } = true;
    }
}
