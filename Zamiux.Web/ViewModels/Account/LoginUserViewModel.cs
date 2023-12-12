using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.ViewModels.Account
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "*")]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
