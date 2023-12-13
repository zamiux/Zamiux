using Zamiux.Web.Entities.Social;

namespace Zamiux.Web.ViewModels.Home
{
    public class ContactHomeViewModel
    {
        public string? ContactPhone { get; set; }
        public string? ContactAddress { get; set; }
        public string? ContactEmailOne { get; set; }
        public string? ContactEmailTwo { get; set; }
        public List<UserSocial> socials { get; set; }
    }
}
