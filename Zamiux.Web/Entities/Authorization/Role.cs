using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Authorization
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string RoleTitle { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
