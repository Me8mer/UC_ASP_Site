using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UMBRAPage.Data;
using UMBRAPage.Models;
using System.Threading.Tasks;

namespace UMBRAPage.Pages.Blogs
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public BlogArticle Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Article = await _context.BlogArticles.FindAsync(id);
            if (Article == null)
                return NotFound();

            return Page();
        }
    }
}
