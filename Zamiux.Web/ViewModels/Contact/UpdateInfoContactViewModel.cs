namespace Zamiux.Web.ViewModels.Contact
{
    public class UpdateInfoContactViewModel
    {
        public string? ContactPhone { get; set; }
        public string? ContactAddress { get; set; }
        public string? ContactEmailOne { get; set; }
        public string? ContactEmailTwo { get; set; }
        public string? ContactLogoDark { get; set; }
        public string? ContactLogo { get; set; }
        public string? ContactLogoDark_old { get; set; }
        public string? ContactLogo_old { get; set; }
        public IFormFile? ImageContactLogo { get; set; }
        public IFormFile? ImageContactLogoDark { get; set; }
    }
}
