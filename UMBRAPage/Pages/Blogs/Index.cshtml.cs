using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UMBRAPage.Data;
using UMBRAPage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UMBRAPage.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BlogArticle> Articles { get; set; } = new();

        public async Task OnGetAsync()
        {
            Articles = await _context.BlogArticles
                .OrderByDescending(a => a.PublishedOn)
                .ToListAsync();
        }
    }
}
