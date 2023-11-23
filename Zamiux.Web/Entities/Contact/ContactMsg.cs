using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Contact
{
    public class ContactMsg
    {
        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string UserEmail { get; set; }
        public string? UserSubject { get; set; }
        public string? UserMessage { get; set; }
    }
}
