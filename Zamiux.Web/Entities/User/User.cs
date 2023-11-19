using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? UserName { get; set; }

        [MaxLength(200)]
        public string UserEmail { get; set; }

        [MaxLength(300)]
        public string UserPassword { get; set; }

        [MaxLength(1000)]
        public string UserImageProfileUrl { get; set; }

        public bool UserStatus { get; set; }
    }
}
