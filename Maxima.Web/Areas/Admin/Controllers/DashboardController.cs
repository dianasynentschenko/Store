

using Maxima.DataAccess.Repository.IRepository;
using Maxima.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Maxima.Utility;

namespace Maxima.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DashboardController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
                  
            var queryTotalToday = _unitOfWork.OrderHeader.GetAll()
                .Where(i => i.OrderDate.Date == DateTime.Now.Date && i.OrderStatus is SD.StatusConfirmed)
                .Select(i => i.OrderTotal);

            ViewBag.SelectTotalToday = queryTotalToday.ToList();

            var queryTotalWeek = _unitOfWork.OrderHeader.GetAll()
              .Where(i => i.OrderDate.Date >= DateTime.Now.Date.AddDays(-7) && i.OrderStatus is SD.StatusConfirmed)
              .Select(i => i.OrderTotal);

            ViewBag.SelectTotalWeek = queryTotalWeek.ToList();

            var queryTotalMonth = _unitOfWork.OrderHeader.GetAll()
             .Where(i => i.OrderDate.Date >= DateTime.Now.Date.AddMonths(-1) && i.OrderStatus is SD.StatusConfirmed)
             .Select(i => i.OrderTotal);

            ViewBag.SelectTotalMonth = queryTotalMonth.ToList();

            var queryTotalQuarter = _unitOfWork.OrderHeader.GetAll()
             .Where(i => i.OrderDate.Date >= DateTime.Now.Date.AddMonths(-3) && i.OrderStatus is SD.StatusConfirmed)
             .Select(i => i.OrderTotal);

            ViewBag.SelectTotalQuarter = queryTotalQuarter.ToList();

           var queryOrdersToday = _unitOfWork.OrderHeader.GetAll()
              .Where(i => i.OrderDate.Date == DateTime.Now.Date && i.OrderStatus is SD.StatusConfirmed)
              .Count();

            ViewBag.SelectOrdersToday = queryOrdersToday;

            var queryOrdersNew = _unitOfWork.OrderHeader.GetAll()
           .Where(i => i.OrderStatus is SD.StatusConfirmed)
           .Count();

            ViewBag.SelectOrdersNew = queryOrdersNew;

            var queryOrdersTodayInProcessing = _unitOfWork.OrderHeader.GetAll()
           .Where(i => i.OrderStatus is SD.StatusInProcessing)
           .Count();

            ViewBag.SelectOrdersTodayInProcessing = queryOrdersTodayInProcessing;      

            var queryOrdersTodaySending = _unitOfWork.OrderHeader.GetAll()
          .Where(i => i.OrderStatus is SD.StatusSending)
          .Count();

            ViewBag.SelectOrdersTodaySending = queryOrdersTodaySending;

            var queryTop5ProductsToday = _unitOfWork.OrderDetail.GetAll()
               .Where(i => i.OrderHeader.OrderDate.Date == DateTime.Now.Date && i.OrderHeader.OrderStatus is SD.StatusConfirmed)
               .OrderByDescending(i => i.Price)
               .Select(i => i.ProductId)
               .Distinct()
               .Take(5);

            ViewBag.SelectTop5ProductsToday = queryTop5ProductsToday.ToList();

            var queryTop5PopularToday = _unitOfWork.OrderDetail.GetAll()               
              .Where(i => i.OrderHeader.OrderDate.Date == DateTime.Now.Date && i.OrderHeader.OrderStatus is SD.StatusConfirmed)
              .OrderByDescending(i => i.Count)
              .Select(i => i.ProductId)                
              .Distinct()
              .Take(5);

            ViewBag.Selectop5PopularToday = queryTop5PopularToday.ToList();

            var queryTopPopularToday = _unitOfWork.OrderDetail.GetAll()
              .Where(i => i.OrderHeader.OrderDate.Date == DateTime.Now.Date && i.OrderHeader.OrderStatus is SD.StatusConfirmed)
              .OrderByDescending(i => i.Count)
              .Select(i => new List<int>() { i.ProductId, i.OrderId })
              .Distinct()
              .Take(5);

            ViewBag.SelectopPopularToday = queryTopPopularToday.ToList();

            DashboardVM dashboardVM = new DashboardVM()
            {
                ProductVM = _unitOfWork.Product.GetAll(includeProperties: "Category"),
                CategorieVM = _unitOfWork.Category.GetAll(),
                OrderHeaderVM= _unitOfWork.OrderHeader.GetAll(),
                OrderDetailVM = _unitOfWork.OrderDetail.GetAll(),

            };
            return View(dashboardVM);
        }

    }
}
