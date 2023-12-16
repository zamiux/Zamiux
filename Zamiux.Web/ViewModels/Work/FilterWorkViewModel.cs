using Zamiux.Web.ViewModels.Common;

namespace Zamiux.Web.ViewModels.Work
{
    public class FilterWorkViewModel:Paging<Zamiux.Web.Entities.Works.Work>
    {
        public string? CategoryName { get; set; }
        public string? WorkName { get; set; }
    }
}
