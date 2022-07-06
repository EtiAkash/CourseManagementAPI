

namespace CourseManagementApi.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual IList<Course> Courses{ get; set; }
       
        public virtual IList<Grade> Grades { get; set; }
    }
}
