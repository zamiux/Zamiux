using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Social
{
    public class UserSocial
    {
        [Key]
        public int Id { get; set; }
        public string? SocialTitle { get; set; }
        public string? SocialIcon { get; set; }
        public string? SocialLink { get; set; }
        public bool isActive { get; set; } = true;
    }
}
