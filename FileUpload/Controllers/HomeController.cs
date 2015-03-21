using FileUpload.Models;
using System.IO;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FileUploadViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var fileName = Path.GetFileName(model.UploadFilePath.FileName);
            var uploadPath = Path.Combine(Server.MapPath("~/uploads/"), fileName);
            model.UploadFilePath.SaveAs(uploadPath);

            model.Url = Url.Content(Path.Combine("/uploads/", fileName));

            return View(model);
        }

        public ActionResult Multiple()
        {
            return View(new MultipleFileUploadViewModel());
        }

        [HttpPost]
        public ActionResult Multiple(MultipleFileUploadViewModel model)
        {
            var selectedPaths = model.UploadFilePaths.Where(f => f != null);
            if (selectedPaths.Count() == 0)
            {
                ModelState.AddModelError(string.Empty, "No files were selected for upload");
                return View(model);
            }

            model.Urls = new List<string>();
            foreach (var path in selectedPaths)
            {
                var fileName = Path.GetFileName(path.FileName);
                var uploadPath = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                path.SaveAs(uploadPath);
                model.Urls.Add(Url.Content(Path.Combine("/uploads/", fileName)));
            }
            return View(model);
        }
    }
}

