using Microsoft.EntityFrameworkCore;
using UMBRAPage.Models;

namespace UMBRAPage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<BlogArticle> BlogArticles { get; set; }
    }
}