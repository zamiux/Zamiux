using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.User
{
    public class UserIntro
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? IntroTitle { get; set; }
        public bool isActive { get; set; } = true;
    }
}
