using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UMBRAPage.Data;
using UMBRAPage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UMBRAPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public required IEnumerable<BlogArticle> Articles { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Articles = await _context.BlogArticles.ToListAsync();
        }
    }
}