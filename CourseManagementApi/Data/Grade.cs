using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApi.Data
{
    public class Grade
    {
        public int Id { get; set; }

        [Range(0,100)]
        public int GradeValue { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
    }
}
