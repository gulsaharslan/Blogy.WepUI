using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Writer", AuthenticationSchemes = "Identity.Application", Policy = "WriterAccessDenied")]
    public class WriterNotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public WriterNotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();
            return View(values);
        }
        
    }
}
