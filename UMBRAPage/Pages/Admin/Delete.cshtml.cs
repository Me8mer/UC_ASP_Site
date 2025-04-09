using Microsoft.AspNetCore.Mvc;
using UMBRAPage.Data;
using UMBRAPage.Models;
using System.Threading.Tasks;

namespace UMBRAPage.Pages.Admin
{
    public class DeleteModel : AdminBasePageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogArticle Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.BlogArticles.FindAsync(id);
            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.BlogArticles.FindAsync(id);
            if (Article != null)
            {
                _context.BlogArticles.Remove(Article);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Blogs/Index");
        }
    }
}
