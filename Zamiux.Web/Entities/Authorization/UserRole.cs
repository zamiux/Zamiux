using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Authorization
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public Role Role { get; set; }

        public Zamiux.Web.Entities.User.User User { get; set; }
    }
}
