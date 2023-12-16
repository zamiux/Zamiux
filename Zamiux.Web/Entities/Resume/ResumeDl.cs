using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Resume
{
    public class ResumeDl
    {
        [Key]
        public int Id { get; set; }
        public int Counter { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
