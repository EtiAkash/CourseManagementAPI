using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagementApi.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Teacher",
                    NormalizedName="TEACHER"
                },
                 new IdentityRole
                 {
                     Name = "Student",
                     NormalizedName = "STUDENT"
                 },
                 new IdentityRole
                 {
                     Name="Admin",
                     NormalizedName="ADMIN"
                 }
                );
        }
    }
}
