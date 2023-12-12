using Zamiux.Web.Entities.Services;
using Zamiux.Web.ViewModels.Common;

namespace Zamiux.Web.ViewModels.Service
{
    public class FilterListServiceViewModel:Paging<UserService>
    {
        public string? ServiceTitle { get; set; }
        public string? ServiceDescription { get; set; }
    }
}
