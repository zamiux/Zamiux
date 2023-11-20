using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.ViewModels.User
{
    public class UpdateUserContentViewModel
    {
        [Required(ErrorMessage ="نام و نام خانوادگی ضروری می باشد")]
        public string? FullName { get; set; }

        [MaxLength(4000,ErrorMessage ="*")]
        public string? UserDescription { get; set; }

        [MaxLength(1000)]
        public string? UserImageProfileUrl { get; set; }

        [MaxLength(1000)]
        public string? UserImageBackgroundUrl { get; set; }
    }
}
