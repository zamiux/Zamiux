using System.ComponentModel.DataAnnotations;

namespace Zamiux.Web.ViewModels.Work
{
    public class EditWorkViewModel
    {
        [Display(Name = "نام دسته بندی پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر داشته باشد")]
        public string CategoryName { get; set; }

        [Display(Name = "عنوان پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر داشته باشد")]
        public string WorkName { get; set; }

        [Display(Name = "لینک پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر داشته باشد")]
        public string WorkExternalUrl { get; set; }

        public string? WorkImg_old { get; set; }

        [Display(Name = "تصویر پروژه")]
        public IFormFile? WorkImg { get; set; }

        [Display(Name = "وضعیت پروژه")]
        public bool IsActive { get; set; }
    }
}
