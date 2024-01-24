using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models
{
    public class StudentsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public GenderEnum Gender { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string PicturePath { get; set; }
    }
}
