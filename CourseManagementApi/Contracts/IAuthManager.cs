using CourseManagementApi.Models.Users;

using Microsoft.AspNetCore.Identity;

namespace CourseManagementApi.Contracts
{
    public interface IAuthManager
    {
        Task  <IEnumerable<IdentityError>> Register(ApiUserDTO userDTO);
        Task<AuthResponseDTO> Login(LoginUserDTO userDTO);
    }
}
