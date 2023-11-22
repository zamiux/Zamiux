using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Contact
{
    public class InfoContact
    {
        [Key]
        public int Id { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactAddress { get; set; }
        public string? ContactEmailOne { get; set; }
        public string? ContactEmailTwo { get; set; }
        public string? ContactLogoDark { get; set; }
        public string? ContactLogo { get; set; }
    }
}
