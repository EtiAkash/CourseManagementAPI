using AutoMapper;

using CourseManagementApi.Contracts;
using CourseManagementApi.Data;
using CourseManagementApi.Models;
using CourseManagementApi.Models.Users;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourseManagementApi.Repositories
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly CourseManagingDbContext _context;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration, CourseManagingDbContext context)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
            this._context = context;
        }

        public async Task<AuthResponseDTO> Login(LoginUserDTO userDTO)
        {
            bool isValidUser = false;

            var user = await _userManager.FindByEmailAsync(userDTO.Email);
            isValidUser = await _userManager.CheckPasswordAsync(user, userDTO.Password);

            if (user == null || isValidUser == false)
            {
                return null;
            }
            var token = await GenerateToken(user);
            return new AuthResponseDTO
            {
                Token = token,
                UserId = user.Id
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDTO userDTO)
        {
            var user = _mapper.Map<ApiUser>(userDTO);
            user.UserName = userDTO.Email;

            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (result.Succeeded)
            {
                if (userDTO.Role.ToLower() == "student")
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                    String Name = user.FirstName + " " + user.LastName;
                    StudentDTO student = new StudentDTO
                    {
                        Name = Name
                    };

                    await _context.Students.AddAsync(_mapper.Map<Student>(student));
                    await _context.SaveChangesAsync();
                }
                else if (userDTO.Role.ToLower() == "teacher")
                {
                    await _userManager.AddToRoleAsync(user, "Teacher");
                    String Name = user.FirstName + " " + user.LastName;
                    TeacherDTO teacher = new TeacherDTO
                    {
                        Name = Name
                    };

                    await _context.Teachers.AddAsync(_mapper.Map<Teacher>(teacher));
                    await _context.SaveChangesAsync();
                }
            }
            return result.Errors;
        }

        private async Task<string> GenerateToken(ApiUser apiUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(apiUser);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(apiUser);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub,apiUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,apiUser.Email),
                new Claim("uid",apiUser.Id),
            }
            .Union(roleClaims).Union(userClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToInt32(_configuration["JwtSettings:DurationInHours"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
