using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.Entities.Works
{
    public class Work
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        [Required]
        [MaxLength(200)]
        public string WorkName { get; set; }

        [Required]
        [MaxLength(200)]
        public string WorkExternalUrl { get; set; }

        [MaxLength(100)]
        public string? WorkImgThumb { get; set; }

        [MaxLength(100)]
        public string? WorkImg { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime WorkDate { get; set; } = DateTime.Now;

    }
}
