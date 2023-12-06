namespace Zamiux.Web.ViewModels.Ability
{
    public class EditUserAbilityViewModel
    {
        public string? AbilityTitle { get; set; }

        public int AbilityPercent { get; set; } = 0;

        public int AbilityPriority { get; set; } = 0;

        public bool isActive { get; set; } = true;
    }
}
