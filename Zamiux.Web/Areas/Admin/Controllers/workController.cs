using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Zamiux.Web.Context;
using Zamiux.Web.Utils;
using Zamiux.Web.Utils.ImageHandler;
using Zamiux.Web.ViewModels.Work;

namespace Zamiux.Web.Areas.Admin.Controllers
{
    public class workController : AdminBsseController
    {
        #region Ctor
        private readonly ZamiuxDbContext _context;
        public workController(ZamiuxDbContext context)
        {
            _context = context;
        }
        #endregion

        #region List Works
        public IActionResult Index(FilterWorkViewModel filterWork)
        {
            //fetch all withoute data
            var QueryWorks = _context.Works.AsQueryable();

            //filters
            if (!string.IsNullOrEmpty(filterWork.WorkName))
            {
                QueryWorks = QueryWorks.Where(x => EF.Functions.Like(x.WorkName, $"%{filterWork.WorkName}%"));
            }

            if (!string.IsNullOrEmpty(filterWork.CategoryName))
            {
                QueryWorks = QueryWorks.Where(x => EF.Functions.Like(x.CategoryName, $"%{filterWork.CategoryName}%"));
            }

            //pagging
            filterWork.SetPagging(QueryWorks);


            return View(filterWork);
        }
        #endregion

        #region Create Work
        [HttpGet]
        public IActionResult Create_Work() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_Work(CreateWorkViewModel createWork)
        {
            if (ModelState.IsValid)
            {
                //generate Imgage Name and Save To Drive With Thumb
                string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(createWork.WorkImg.FileName);
                createWork.WorkImg.AddImageToServer(imageName, PathExtension.WorkImageOrginServer, 100, 100, PathExtension.WorkImageOrginServerThumb);

                var work_db = new Zamiux.Web.Entities.Works.Work()
                {
                    CategoryName = createWork.CategoryName,
                    WorkName = createWork.WorkName,
                    IsActive = true,
                    WorkExternalUrl = createWork.WorkExternalUrl,
                    WorkImg = imageName,
                    WorkImgThumb = imageName
                };

                _context.Works.Add(work_db);
                _context.SaveChanges();
                return RedirectToAction("Index","work");
            }

            return View(createWork);
        }
        #endregion

        #region Edit Work
        public IActionResult Edit_Work(int id)
        {
            //fetch data from db
            
            return View();
        }
        #endregion
    }
}
