using blamato.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace blamato.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }
        
        
        
        public Task<ServiceResponse<bool>> ChangePassword(int userId, string password)
        {
            throw new NotImplementedException();
        }

        public int GetUserId()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();

            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));

            if(user is null)
            {
                response.Sucess = false;
                response.Message = "User not found.";
            }else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Sucess = false;
                response.Message = "Password is not correct.";
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response;

        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExist(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Sucess = false,
                    Message = "User already exist"
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration complete!" };



        }

        public async Task<bool> UserExist(string email)
        {
            if (await _dataContext.Users.AnyAsync(user => user.Email.ToLower()
                .Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;


        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

    }
}
