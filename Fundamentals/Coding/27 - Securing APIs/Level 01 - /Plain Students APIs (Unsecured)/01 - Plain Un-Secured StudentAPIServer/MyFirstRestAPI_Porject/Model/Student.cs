using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Range(0, 150)]
        public int Age { get; set; }

        [Range(0, 100)]
        public int Grade { get; set; }
    }
}
