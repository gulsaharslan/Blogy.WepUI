using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Views.ViewComponents.AdminLayoutViewComponent
{
    [Area("Admin")]
    public class AdminLayoutMessageComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IMessageService _messageService;
        private readonly BlogContext _context;

        public AdminLayoutMessageComponentPartial(IMessageService messageService, BlogContext context, UserManager<AppUser> userManager)
        {

            _context = context;
            _messageService = messageService;
            _userManager = userManager;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.message = _context.Messages.Count();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _messageService.TGetLastThreeMessagesByWriter(user.Id);
            return View(values);
        }
    }
}
