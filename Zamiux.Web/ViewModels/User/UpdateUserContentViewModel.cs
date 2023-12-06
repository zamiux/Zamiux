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

        public string? ImageProfile_old { get; set; }
        public string? ImageBackground_old { get; set; }
        public IFormFile? ImageProfileUrl { get; set; }
        public IFormFile? ImageBackgroundUrl { get; set; }

    }
}
