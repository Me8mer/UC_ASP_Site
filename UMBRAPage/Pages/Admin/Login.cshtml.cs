using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UMBRAPage.Pages.Admin
{
    public class LoginModel : PageModel
    {
        // Bind properties for the login form
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        // For demonstration, we hardcode the admin credentials.
        // In a real application, never store credentials in code.
        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "password")
            {
                // Set a session variable indicating the admin is logged in
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToPage("/Admin/Index"); // Redirect to admin dashboard or list page
            }
            ErrorMessage = "Invalid credentials, please try again.";
            return Page();
        }
    }
}
