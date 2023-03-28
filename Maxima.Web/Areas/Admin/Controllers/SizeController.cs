using Maxima.DataAccess.Repository.IRepository;
using Maxima.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maxima.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SizeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Size> objSizeList = _unitOfWork.Size.GetAll();
            return View(objSizeList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Size obj)
        {
            if (obj.Name == obj.Count.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Size.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Size created successfully";
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

            var sizeFromDbFirst = _unitOfWork.Size.GetFirstOrDefault(u => u.Id == id);

            if (sizeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(sizeFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Size obj)
        {
            if (obj.Name == obj.Count.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Size.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Size updated successfully";
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
            var sizeFromDbFirst = _unitOfWork.Size.GetFirstOrDefault(u => u.Id == id);

            if (sizeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(sizeFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Size.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Size.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Size deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
