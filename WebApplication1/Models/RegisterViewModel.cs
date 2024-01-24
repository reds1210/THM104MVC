using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "姓名")]
        [StringLength(5)]
        public string Name { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "打兩次都打錯?!腦殘遊記")]
        public string PasswordConfirm { get; set; }

        [RegularExpression(@"09\d{8}", ErrorMessage = "手機號碼是不會打逆?!")]
        public string Phone { get; set; }

        public IFormFile? File { get; set; }
    }
}
