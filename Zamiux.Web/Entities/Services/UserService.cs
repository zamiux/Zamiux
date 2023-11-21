using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Services
{
    public class UserService
    {
        [Key]
        public int Id { get; set; }
        public string? ServiceTitle { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceIcon { get; set; }
        public bool isActive { get; set; } = true;
    }
}
