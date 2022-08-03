using CourseManagementApi.Data;

namespace CourseManagementApi.Contracts
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task EnrollAsync(int id, int studenId);
        Task<Teacher> GetTeacher(int id);
        Task<Student> GetStudent(int id);
        Task<Course> GetCourse(int id);
        Task GradeAsync(int id, int studentId, int gradeValue);
        Task<Student> GetStudentGrades(int id);
        Task<List<Student>> GetAllStudents();
        Task<List<Teacher>> GetAllTeachers();
    }
}