using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.ViewModels.Contact
{
    public class SendContactMsgViewModel
    {
        [Required(ErrorMessage ="*")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "*")]
        public string UserEmail { get; set; }
        public string? UserSubject { get; set; }
        public string? UserMessage { get; set; }
    }
}
