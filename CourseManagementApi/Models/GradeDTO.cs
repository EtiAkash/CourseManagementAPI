using System.ComponentModel.DataAnnotations;

namespace CourseManagementApi.Models
{
    public class GradeDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Grade is required")]
        public int? GradeValue { get; set; }
    }
}
