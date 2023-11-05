using Authenticator.Common;
using Authenticator.Data;
using Authenticator.DTO;
using Authenticator.Helpers;
using Authenticator.Logs;
using Authenticator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authenticator.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JWT _jwt;
        private readonly DataBaseContext _context;
        public AuthenticationService(DataBaseContext context, IOptions<JWT> jwt, ILogger<AuthenticationService> logger)
        {
            _context = context;
            _jwt = jwt.Value;
        }
        public async Task<Message> GetTokenAsync(LoginDto model)
        {
            Message message = new Message();
            //var user = await _context.Users.DefaultIfEmpty().Include(rol => rol.Roles)
            //                                             .FirstOrDefaultAsync(x => x.Email.ToLower() == model.Email.ToLower());

            //if (user == null)
            //{
            //    message.EstaAutenticado = false;
            //    return message;
            //}

            //var password = HashPasswordToBase64(model.Password);
            //var result = VerifyHashedPassword(user.Identification, password);

            //if (result == true)
            //{
            //    message.EstaAutenticado = true;
            //    JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
            //    message.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken); //escribe el token
            //    message.Email = user.Email;
            //    message.Name = user.Name;
            //    message.Roles = user.Roles.Name;
            //    LogResquest.GenerateTokenFile(message.Email, message.Roles);
            //    return message;
            //}

            //message.EstaAutenticado = false;
            return message;
        }
        private JwtSecurityToken CreateJwtToken(Users userDto)
        {
            //var claims = new[]
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub, userDto.Name),
            //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //            new Claim(JwtRegisteredClaimNames.Email, userDto.Email)
            //};

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            //claims: claims,
            audience: _jwt.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        private string HashPasswordToBase64(string password)
        {
            //using (SHA256 sha256Hash = SHA256.Create())
            //{
            //    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            //    string base64Hash = Convert.ToBase64String(bytes);

            //    return base64Hash;
            //}
            return "base64Hash";//ELIMINAR LINEA
        }
        private bool VerifyHashedPassword(string enteredPassword, string storedHash)
        {
            //using (SHA256 sha256Hash = SHA256.Create())
            //{
            //    byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);
            //    byte[] hashBytes = Convert.FromBase64String(storedHash);
            //    byte[] computedHash = sha256Hash.ComputeHash(enteredPasswordBytes);

            //    // Comparar los dos hashes the encript and the send
            //    for (int i = 0; i < computedHash.Length; i++)
            //    {
            //        if (computedHash[i] != hashBytes[i])
            //        {
            //            return false;
            //        }
            //    }
            //    return true;
            //}
            return true; //ELIMINAR LINEA
        }
    }
}