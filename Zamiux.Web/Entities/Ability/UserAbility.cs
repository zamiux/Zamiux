using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Ability
{
    public class UserAbility
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? AbilityTitle { get; set; }

        [MaxLength(20)]
        public int AbilityPercent { get; set; } = 0;

        [MaxLength(20)]
        public int AbilityPriority { get; set; } = 0;
        public bool isActive { get; set; } = true;
    }
}
