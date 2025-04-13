using System;
using System.ComponentModel.DataAnnotations;

namespace UMBRAPage.Models
{
    public class BlogArticle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        public DateTime PublishedOn { get; set; } = DateTime.UtcNow;

        public DateTime? LastEdited { get; set; }  

        [StringLength(100)]
        public string? Author { get; set; }        
    }
}
