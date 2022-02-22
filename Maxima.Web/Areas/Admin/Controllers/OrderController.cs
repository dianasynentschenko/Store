
using Maxima.DataAccess.Repository.IRepository;
using Maxima.Models;
using Maxima.Models.ViewModels;
using Maxima.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maxima.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize (Roles = SD.Role_Admin + "," + SD.Role_Order_Manager)]
   
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public OrderVM OrderVM { get; set; }

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int orderId)
        {
            OrderVM = new OrderVM()
            {
                OrderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(u => u.Id == orderId, includeProperties: "ApplicationUser"),
                OrderDetail = _unitOfWork.OrderDetail.GetAll(u => u.OrderId == orderId, includeProperties: "Product"),
            };

            return View(OrderVM);
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOrderDetail()
        {
            var orderHEaderFromDb = _unitOfWork.OrderHeader.GetFirstOrDefault(u => u.Id == OrderVM.OrderHeader.Id, tracked: false);
            orderHEaderFromDb.Name = OrderVM.OrderHeader.Name;
            orderHEaderFromDb.PhoneNumber = OrderVM.OrderHeader.PhoneNumber;
            orderHEaderFromDb.StreetAddress = OrderVM.OrderHeader.StreetAddress;
            orderHEaderFromDb.City = OrderVM.OrderHeader.City;
            orderHEaderFromDb.State = OrderVM.OrderHeader.State;
            orderHEaderFromDb.PostalCode = OrderVM.OrderHeader.PostalCode;
           
            _unitOfWork.OrderHeader.Update(orderHEaderFromDb);
            _unitOfWork.Save();
            TempData["Success"] = "Order Details Updated Successfully.";
            return RedirectToAction("Details", "Order", new { orderId = orderHEaderFromDb.Id });
        }

        
        [HttpPost]   
        [ValidateAntiForgeryToken]
        public IActionResult Confirmed()
        {
            _unitOfWork.OrderHeader.UpdateStatus(OrderVM.OrderHeader.Id, SD.StatusConfirmed);
            _unitOfWork.Save();
            TempData["Success"] = "Order Status Updated Successfully.";
            return RedirectToAction("Details", "Order", new { orderId = OrderVM.OrderHeader.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InProcessing()
        {
            _unitOfWork.OrderHeader.UpdateStatus(OrderVM.OrderHeader.Id, SD.StatusInProcessing);
            _unitOfWork.Save();
            TempData["Success"] = "Order Status Updated Successfully.";
            return RedirectToAction("Details", "Order", new { orderId = OrderVM.OrderHeader.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sending()
        {
            _unitOfWork.OrderHeader.UpdateStatus(OrderVM.OrderHeader.Id, SD.StatusSending);
            _unitOfWork.Save();
            TempData["Success"] = "Order Status Updated Successfully.";
            return RedirectToAction("Details", "Order", new { orderId = OrderVM.OrderHeader.Id });
        }

        #region API CALLS
        [HttpGet]       
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeader> orderHeaders;
           
            orderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");

            switch (status)
            {             
                case "newOrder":
                    orderHeaders = orderHeaders.Where(u => u.OrderStatus == SD.StatusNewOrder);
                    break;
                case "confirmed":
                    orderHeaders = orderHeaders.Where(u => u.OrderStatus == SD.StatusConfirmed);
                    break;
                case "inProcessing":
                    orderHeaders = orderHeaders.Where(u => u.OrderStatus == SD.StatusInProcessing);
                    break;
                case "sending":
                    orderHeaders = orderHeaders.Where(u => u.OrderStatus == SD.StatusSending);
                    break;
                case "receive":
                    orderHeaders = orderHeaders.Where(u => u.OrderStatus == SD.StatusReceive);
                    break;
                default:
                    break;
            }

            return Json(new { data = orderHeaders});
        }
        #endregion
    }
}
