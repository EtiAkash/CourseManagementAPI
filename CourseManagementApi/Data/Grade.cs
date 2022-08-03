using CourseManagementApi.Models;

using FluentValidation;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApi.Data
{
    public class Grade
    {
        public int Id { get; set; }       
        
        public int? GradeValue { get; set; } = 0;

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
    }

    public class GradeValidator : AbstractValidator<GradeDTO>
    {
        public GradeValidator()
        {
            RuleFor(p => p.GradeValue).NotEmpty().WithMessage("Grade is required")
                                      .LessThanOrEqualTo(100).WithMessage("Grade must not be more than 100")
                                      .GreaterThanOrEqualTo(0).WithMessage("Grade must not be less than 0");
        }
    }
}
