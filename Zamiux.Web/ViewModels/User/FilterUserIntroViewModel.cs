using Zamiux.Web.Entities.Ability;
using Zamiux.Web.Entities.User;
using Zamiux.Web.ViewModels.Common;

namespace Zamiux.Web.ViewModels.User
{
    public class FilterUserIntroViewModel : Paging<UserIntro>
    {
        public string? IntroTitle { get; set; }
    }
}
