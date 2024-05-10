using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blogy.WepUI.Areas.Writer.Views.ViewComponents.DashboardViewComponent
{
    [Area("Writer")]
    public class WriterAdminNotificationComponentPartial:ViewComponent
    {
        private readonly INotificationService _notificationService;
        public WriterAdminNotificationComponentPartial(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _notificationService.TGetListAll();
            return View(values);
        }
    }
}
