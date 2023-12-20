using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Authorization
{
    public class RolePermission
    {
        [Key]
        public int Id { get; set; }

        #region Foreign key

        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        #endregion

        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
