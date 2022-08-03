using CourseManagementApi.Contracts;
using CourseManagementApi.Data;
using CourseManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementApi.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly CourseManagingDbContext _context;
        public CourseRepository(CourseManagingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task EnrollAsync(int id, int studentId)
        {
            var course = await GetAsync(id);
            var student = await _context.Students.FindAsync(studentId);
            Grade grade = new Grade()
            {
                StudentId = studentId,
                CourseId = id,
            };
            _context.Add(grade);
            await _context.SaveChangesAsync();
            if (course.Students == null)
            {
                course.Students = new List<Student>();
            }
            course.Students.Add(student);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> CourseExists(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            return course != null;
        }

        public async Task<Teacher> GetTeacher(int id)
        {
            return await _context.Teachers.Include(q => q.Courses)
                                           .FirstOrDefaultAsync(p => p.Id == id);

        }
        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.Include(q => q.Courses)
                                          .ThenInclude(q => q.Teacher)
                                          .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Student> GetStudentGrades(int id)
        {
            return await _context.Students.Include(q => q.Grades)
                                          .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _context.Courses.Include(q => q.Teacher)
                                         .Include(q => q.Students)
                                         .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task GradeAsync(int id, int studentId, int gradeValue)
        {
            var grade = await _context.Grades.FirstOrDefaultAsync(p => p.CourseId == id && p.StudentId == studentId);
            grade.GradeValue = gradeValue;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
