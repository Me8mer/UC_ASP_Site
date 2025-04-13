using System;
using System.ComponentModel.DataAnnotations;

namespace UMBRAPage.Models
{
    public class AdminUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Username { get; set; }

        [Required]
        public required string PasswordHash { get; set; }
    }
}
