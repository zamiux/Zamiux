using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.ViewModels.Ability
{
    public class CreateUserAbilityViewModel
    {
        [MaxLength(200,ErrorMessage ="*")]
        public string? AbilityTitle { get; set; }

        public int AbilityPercent { get; set; } = 0;

        public int AbilityPriority { get; set; } = 0;

        public bool isActive { get; set; } = true;
    }
}
