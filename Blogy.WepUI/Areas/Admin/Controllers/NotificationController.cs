using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application", Policy = "AdminAccessDenied")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult NotificationList()
        {
            var values=_notificationService.TGetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNotification(Notification notification)
        {
            _notificationService.TInsert(notification);

            return Redirect("/Admin/Notification/NotificationList");
        }

        public IActionResult DeleteNotification(int id)
        {
            _notificationService.TDelete(id);
            return Redirect("/Admin/Notification/NotificationList");
        }
    }
}
