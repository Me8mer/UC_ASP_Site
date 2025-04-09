using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UMBRAPage.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnPost()
        {
            Console.WriteLine($"Method: {Request.Method}");

            Console.WriteLine("POST hit");
            // Remove the admin flag from the session
            HttpContext.Session.Remove("IsAdmin");
            // Redirect to the home page after logout
            return RedirectToPage("/Index");
        }

        public IActionResult OnGet()
        {
            Console.WriteLine("GET hit");
            return RedirectToPage("/Index");
        }
    }
}
