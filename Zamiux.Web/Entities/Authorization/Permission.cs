using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Authorization
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string TitlePermissionFa { get; set; }

        [MaxLength(255)]
        public string TitlePermission { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
