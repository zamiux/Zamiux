using Azure;
using Zamiux.Web.Entities.Social;
using Zamiux.Web.ViewModels.Common;

namespace Zamiux.Web.ViewModels.Social
{
    public class FilterUserSocialViewModel: Paging<UserSocial>
    {
        public string? SocialTitle { get; set; }
    }
}
