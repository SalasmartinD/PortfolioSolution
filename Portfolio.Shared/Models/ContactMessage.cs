// 📄 Portfolio.Shared/Models/ContactMessage.cs

using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared.Models
{
    public class ContactMessage
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required, StringLength(500, MinimumLength = 10)]
        public string Message { get; set; } = string.Empty;
    }
}