namespace CourseManagementApi.Models
{
    public class TeacherCourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<StudentDetailsDTO> Students { get; set; }
    }
}
