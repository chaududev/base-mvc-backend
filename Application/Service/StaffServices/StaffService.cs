using Infrastructure.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace Application.Service.StaffServices
{
    public class StaffService : IStaffService
    {
        readonly IConfiguration configuration;

        readonly IStaffRepository StaffRepository;

        public StaffService(IConfiguration configuration, IStaffRepository StaffRepository)
        {
            this.configuration = configuration;
            this.StaffRepository = StaffRepository;
        }
        public string HashPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            string hashedPassword = Convert.ToBase64String(hash);
            return hashedPassword;
        }


        public string Token(string email, string password)
        {
           
            var Staff = StaffRepository.GetStaff(email, HashPassword(password));
            if (Staff == null)
            {
                throw new Exception("Invalid credentials");
            }

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", Staff.Id.ToString()),
                        new Claim("FullName",Staff.FullName),
                        new Claim("RoleId",Staff.RoleId.ToString()),
                        new Claim(ClaimTypes.Role, Staff.RoleId==1?"Admin":Staff.RoleId==2?"Accountant":"Other"),
                        new Claim("Email", Staff.Email)
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
