using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApi.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Student>Students{ get; set; }
        public virtual IList<Grade> Grades { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public  int TeacherId {get;set;}
        public Teacher Teacher { get; set; }
    }
}