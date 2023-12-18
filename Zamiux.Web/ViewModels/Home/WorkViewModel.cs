using Zamiux.Web.Entities.Works;

namespace Zamiux.Web.ViewModels.Home
{
    public class WorkViewModel
    {
        public List<Zamiux.Web.Entities.Works.Work> ListWorks { get; set; } = new List<Entities.Works.Work>();
        public List<string> categoryWork { get; set; }
    }
}
