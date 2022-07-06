using CourseManagementApi.Data.Configurations;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementApi.Data
{
    public class CourseManagingDbContext : IdentityDbContext<ApiUser>
    {
        public CourseManagingDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }      
        public DbSet<Grade> Grades { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
