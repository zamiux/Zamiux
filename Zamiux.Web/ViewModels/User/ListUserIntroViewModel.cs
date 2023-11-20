using System.ComponentModel.DataAnnotations;
using Zamiux.Web.Entities.User;

namespace Zamiux.Web.ViewModels.User
{
    public class ListUserIntroViewModel
    {
        public List<UserIntro> userIntros { get; set; }
    }
}
