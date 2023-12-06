using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.ViewModels.User
{
    public class EditUserIntroViewModel
    {
        [MaxLength(200, ErrorMessage = "*")]
        public string? IntroTitle { get; set; }
        public bool isActive { get; set; } = true;
    }
}
