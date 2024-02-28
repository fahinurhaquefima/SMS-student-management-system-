using System.ComponentModel.DataAnnotations;

namespace SMS.WebApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
