using Maxima.DataAccess.Repository.IRepository;
using Maxima.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maxima.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdditionalImgController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdditionalImgController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<AdditionalImg> objAdditionalImgList = _unitOfWork.AdditionalImg.GetAll();
            return View(objAdditionalImgList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdditionalImg obj, IFormFile? PostedFile)

        {

            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (PostedFile != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(PostedFile.FileName);

                    if (obj.AdditionalImgUrl != null)
                    {
                        var oldImagePath1 = Path.Combine(wwwRootPath, obj.AdditionalImgUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath1))
                        {
                            System.IO.File.Delete(oldImagePath1);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        PostedFile.CopyTo(fileStreams);
                    }
                    obj.AdditionalImgUrl = @"\images\products\" + fileName + extension;

                }


                _unitOfWork.AdditionalImg.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "AdditionalImg created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var additionalImgFromDbFirst = _unitOfWork.AdditionalImg.GetFirstOrDefault(u => u.Id == id);

            if (additionalImgFromDbFirst == null)
            {
                return NotFound();
            }

            return View(additionalImgFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AdditionalImg obj)
        {            
            if (ModelState.IsValid)
            {
                _unitOfWork.AdditionalImg.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "AdditionalImg updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var additionalImgFromDbFirst = _unitOfWork.AdditionalImg.GetFirstOrDefault(u => u.Id == id);

            if (additionalImgFromDbFirst == null)
            {
                return NotFound();
            }

            return View(additionalImgFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.AdditionalImg.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.AdditionalImg.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "AdditionalImg deleted successfully";
            return RedirectToAction("Index");

        }
    }


}
