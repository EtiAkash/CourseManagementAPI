using AutoMapper;

using CourseManagementApi.Contracts;
using CourseManagementApi.Data;
using CourseManagementApi.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CourseManagementController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseManagementController(ICourseRepository courseRepository, IMapper mapper)
        {
            this._courseRepository = courseRepository;
            this._mapper = mapper;
        }

        // GET: api/StudentCourses
        //HomePage when not logged in
        [HttpGet]
        [Route("Home")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllAsync();
            var records = _mapper.Map<List<CourseDTO>>(courses);
            return Ok(records);
        }

        // HomePage when logged in as Teacher
        [HttpGet]
        [Authorize(Roles = "Teacher")]
        [Route("teacher/courses")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetTeacherCourses(int id)
        {
            var teacher = await _courseRepository.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            if (teacher.Courses == null)
            {
                return NotFound("No courses are found for this Teacher");
            }
            var records = _mapper.Map<List<CourseDTO>>(teacher.Courses);
            return Ok(records);
        }

        //course details of particular course when logged in as teacher 
        [HttpGet]
        [Authorize(Roles = "Teacher")]
        [Route("teacher/course{id}")]
        public async Task<ActionResult<TeacherCourseDTO>> GetTeacherCourse([FromRoute] int id)
        {
            if (!await CourseExists(id))
            {
                return NotFound("Course is Not Found");
            }
            else
            {
                var course = await _courseRepository.GetCourse(id);
                if (course == null)
                {
                    return NotFound();
                }
                var record = _mapper.Map<TeacherCourseDTO>(course);
                record.Students = _mapper.Map<List<StudentDetailsDTO>>(course.Students);
                return Ok(record);
            }
        }
        //post a new course
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<PostCourseDTO>> PostCourse(PostCourseDTO courseDTO)
        {
            var course = _mapper.Map<Course>(courseDTO);
            await _courseRepository.AddAsync(course);
            return CreatedAtAction("PostCourse", new { id = course.Id }, course);
        }
        //grade a course
        [HttpPatch]
        [Authorize(Roles = "Teacher")]
        [Route("teacher/course{id}/grade")]
        public async Task<IActionResult> GradeCourse([FromRoute] int id, int studentId, int gradeValue)
        {
            await _courseRepository.GradeAsync(id, studentId, gradeValue);
            return Ok();
        }

        // DELETE: api/StudentCourses/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseRepository.DeleteAsync(id);
            return Ok("Course Deleted");
        }

        //Home page when logged in as Student
        [HttpGet]
        [Authorize(Roles = "Student")]
        [Route("student/courses/")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetStudentCourses(int id)
        {
            var student = await _courseRepository.GetStudent(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            if (!student.Courses.Any())
            {
                return NotFound("Student is not enrolled in any courses");
            }
            var records = _mapper.Map<List<CourseDTO>>(student.Courses);
            return Ok(records);
        }

        // course details for a particular course when logged in as student
        [HttpGet()]
        [Authorize(Roles = "Student")]
        [Route("student/course{id}")]
        public async Task<ActionResult<StudentCourseDTO>> GetStudentCourse([FromRoute] int id)
        {
            if (!await CourseExists(id))
            {
                return NotFound("Course is Not Found");
            }
            else
            {
                var course = await _courseRepository.GetAsync(id);
                if (course == null)
                {
                    return NotFound();
                }
                var record = _mapper.Map<StudentCourseDTO>(course);
                int teacherId = course.TeacherId;
                Teacher teacher = await _courseRepository.GetTeacher(teacherId);
                record.TeacherName = teacher.Name;
                return Ok(record);
            }
        }
        //enrol option for a student
        [HttpPatch]
        [Authorize(Roles = "Student")]
        [Route("student/course{id}/enroll")]
        public async Task<IActionResult> PatchCourse([FromRoute] int id, int studentId)
        {
            await _courseRepository.EnrollAsync(id, studentId);
            return Ok("Successfully enrolled");
        }
        [HttpGet]
        [Authorize(Roles = "Student")]
        [Route("student{id}/view_grades")]
        public async Task<ActionResult<IEnumerable<GradeDTO>>> ViewGrades([FromRoute] int id)
        {
            var student = await _courseRepository.GetStudentGrades(id);
            var grades = _mapper.Map<List<GradeDTO>>(student.Grades);
            foreach (var grade in grades)
            {
                var course = await _courseRepository.GetCourse(grade.CourseId);
                grade.CourseName = course.Name;
            }
            return Ok(grades);
        }

        [HttpGet]
        [Route("getallstudents")]
        public async Task<ActionResult<IEnumerable<StudentDetailsDTO>>> GetAllStudents()
        {
            var students = await _courseRepository.GetAllStudents();
            var records = _mapper.Map<List<StudentDetailsDTO>>(students);
            return Ok(records);
        }

        [HttpGet]
        [Route("getallteachers")]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllTeachers()
        {
            var teachers = await _courseRepository.GetAllTeachers();
            var records = _mapper.Map<List<TeacherDTO>>(teachers);
            return Ok(records);
        }

        private async Task<bool> CourseExists(int id)
        {
            return await _courseRepository.CourseExists(id);
        }
    }
}
