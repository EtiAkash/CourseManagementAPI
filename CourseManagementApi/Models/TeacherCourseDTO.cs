namespace CourseManagementApi.Models
{
    public class TeacherCourseDTO : TeacherDTO
    {
        public int Id { get; set; }
        public IList<StudentDetailsDTO> Students { get; set; }
    }
}
