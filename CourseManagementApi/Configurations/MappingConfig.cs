using AutoMapper;

using CourseManagementApi.Data;
using CourseManagementApi.Models;
using CourseManagementApi.Models.Users;

namespace CourseManagementApi.Configurations
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Course, StudentCourseDTO>().ReverseMap();
            CreateMap<Course, TeacherCourseDTO>().ReverseMap();
            CreateMap<Course, PostCourseDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, StudentDetailsDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<ApiUser, ApiUserDTO>().ReverseMap();
            CreateMap<Grade, GradeDTO>().ReverseMap();
        }
    }
}
