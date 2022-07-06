using System.ComponentModel.DataAnnotations;

namespace CourseManagementApi.Models.Users
{
    public class ApiUserDTO:LoginUserDTO
    {
        [Required]
        public string Role { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
             
    }
}
