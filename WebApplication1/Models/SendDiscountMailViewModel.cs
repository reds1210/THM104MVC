using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SendDiscountMailViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
