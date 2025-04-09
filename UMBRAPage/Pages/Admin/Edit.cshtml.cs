using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UMBRAPage.Data;
using UMBRAPage.Models;
using System.Threading.Tasks;

namespace UMBRAPage.Pages.Admin
{
    public class EditModel : AdminBasePageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public BlogArticle Article { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Article).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("/Blogs/Index");
        }
    }
}
