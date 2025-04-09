using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UMBRAPage.Data;
using UMBRAPage.Models;
using System.Threading.Tasks;

namespace UMBRAPage.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public BlogArticle Article { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BlogArticles.Add(Article);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Blogs/Index");
        }
    }
}
