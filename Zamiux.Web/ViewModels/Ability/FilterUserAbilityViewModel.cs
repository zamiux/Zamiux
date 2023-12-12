using Zamiux.Web.Entities.Ability;
using Zamiux.Web.ViewModels.Common;

namespace Zamiux.Web.ViewModels.Ability
{
    public class FilterUserAbilityViewModel: Paging<UserAbility>
    {
        public string? AbilityTitle { get; set; }

        public string? AbilityPercent { get; set; }

        public string? AbilityPriority { get; set; }

        //movaghati inja hastesh
        //public List<UserAbility> userAbilities { get; set; } , dg niazi nist
    }
}
