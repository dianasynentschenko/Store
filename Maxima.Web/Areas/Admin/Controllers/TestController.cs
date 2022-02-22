using Maxima.DataAccess.Repository.IRepository;
using Maxima.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maxima.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Test> objTestList = _unitOfWork.Test.GetAll();
            return View(objTestList);
        }

        //GET
        public IActionResult Create(int? tovarid)
        {


           ViewBag.tovarid = tovarid;
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Test obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}

            


            if (ModelState.IsValid)
            {
               

                _unitOfWork.Test.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Test created successfully";
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

            var testFromDbFirst = _unitOfWork.Test.GetFirstOrDefault(u => u.Id == id);

            if (testFromDbFirst == null)
            {
                return NotFound();
            }

            return View(testFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Test obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Test.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Test updated successfully";
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
            var testFromDbFirst = _unitOfWork.Test.GetFirstOrDefault(u => u.Id == id);

            if (testFromDbFirst == null)
            {
                return NotFound();
            }

            return View(testFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Test.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Test.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Test deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
