using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Zamiux.Web.Context;
using Zamiux.Web.Utils;
using Zamiux.Web.Utils.ImageHandler;
using Zamiux.Web.ViewModels.Service;
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
        [HttpGet]
        public IActionResult Edit_Work(int id)
        {
            //fetch data from db
            //get usr work
            var user_work = _context.Works.SingleOrDefault(s => s.Id == id);
            if (user_work == null) return NotFound();

            //new instance of VM and fill with value got Model and show in View
            var workModel = new EditWorkViewModel()
            {
                CategoryName = user_work.CategoryName,
                WorkName = user_work.WorkName,
                IsActive = user_work.IsActive,
                WorkExternalUrl= user_work.WorkExternalUrl,
                WorkImg_old = user_work.WorkImg,
            };

            return View(workModel);
        }

        [HttpPost]
        public IActionResult Edit_Work(int id,EditWorkViewModel modelWork)
        {
            //fetch data from db
            //get usr work
            var user_work = _context.Works.SingleOrDefault(s => s.Id == id);
            if (user_work == null) return NotFound();

            if (ModelState.IsValid)
            {
                string imageName = modelWork.WorkImg_old;
                if (modelWork.WorkImg != null)
                {
                    imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(modelWork.WorkImg.FileName);
                    modelWork.WorkImg.AddImageToServer(imageName, PathExtension.WorkImageOrginServer, 100, 100, PathExtension.WorkImageOrginServerThumb, user_work.WorkImg);
                    
                    user_work.WorkImg = imageName;
                    user_work.WorkImgThumb = imageName;
                }

                user_work.WorkExternalUrl = modelWork.WorkExternalUrl;
                user_work.WorkName = modelWork.WorkName;    
                user_work.CategoryName = modelWork.CategoryName;
                user_work.IsActive = modelWork.IsActive;

                _context.Works.Update(user_work);
                _context.SaveChanges();
                // todo: set message
                return RedirectToAction("Index");

            }
            return View();
        }
        #endregion

        #region Delete Work
        public IActionResult Delete_Work(int id)
        {
            //get usr work
            var user_work = _context.Works.SingleOrDefault(s => s.Id == id);
            if (user_work == null) return NotFound();

            //delete image if record is pic or file exists
            if (!string.IsNullOrEmpty(user_work.WorkImg))
                user_work.WorkImg.DeleteImage(PathExtension.WorkImageOrginServer, PathExtension.WorkImageOrginServerThumb);

            // delte record 
            _context.Works.Remove(user_work);
            _context.SaveChanges();

            return new JsonResult(new
            {
                status = "success"
            });
        }
        #endregion
    }
}
