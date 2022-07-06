using CourseManagementApi.Contracts;
using CourseManagementApi.Data;

namespace CourseManagementApi.Repositories
{
    public class TeacherRepository:GenericRepository<Course>,ITeacherRepository
    {
        public TeacherRepository(CourseManagingDbContext context ):base(context)
        {            
        }
    }
}
