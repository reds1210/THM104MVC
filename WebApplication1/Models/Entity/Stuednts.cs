using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entity
{
    public enum GenderEnum
    {
        Girl=0,
        Boy=1
    }
    public class Stuednts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenderEnum Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        
        public string Phone { get; set; }

        public string PicturePath { get; set; }
    }
}
