using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.ViewModels.User
{
    public class UpdateUserContentViewModel
    {
        [MaxLength(200)]
        public string? FullName { get; set; }

        [MaxLength(4000)]
        public string? UserDescription { get; set; }

        [MaxLength(1000)]
        public string? UserImageProfileUrl { get; set; }

        [MaxLength(1000)]
        public string? UserImageBackgroundUrl { get; set; }
    }
}
