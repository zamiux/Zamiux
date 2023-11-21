namespace Zamiux.Web.ViewModels.Service
{
    public class CreateUserSevicesViewModel
    {
        public string? ServiceTitle { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceIcon { get; set; }
        public bool isActive { get; set; } = true;
    }
}
