using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UMBRAPage.Pages.Admin
{
    public class AdminBasePageModel : PageModel
    {
        public override void OnPageHandlerExecuting(Microsoft.AspNetCore.Mvc.Filters.PageHandlerExecutingContext context)
        {
            // Check session variable to see if the admin is logged in
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            if (string.IsNullOrEmpty(isAdmin) || isAdmin != "true")
            {
                // Redirect to login if not authenticated
                context.Result = new RedirectToPageResult("/Admin/Login");
            }

            base.OnPageHandlerExecuting(context);
        }
    }
}
