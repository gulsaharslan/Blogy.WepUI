using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Writer.Views.ViewComponents.LayoutViewComponenet
{
    [Area("Writer")]
    public class _LayoutNotificationComponentPartial:ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly BlogContext _context;

        public _LayoutNotificationComponentPartial(INotificationService notificationService,BlogContext context)
        {
            _notificationService = notificationService;
            _context = context;
            
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.notification = _context.Notifications.Count();
            var values = _notificationService.TGetListAll();
            return View(values);
        }
    }
}
