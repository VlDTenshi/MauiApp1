using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MauiApp1.Api
{
    public class TokenService (IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;
        /*JWT
         * SecretKey
         * Audience
         * Issuer
         * Expiration
         */
        //public TokenService(IConfiguration configuration)
        //{

        //    _configuration = configuration;
        //}

        public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration) =>
        
            new ()
            {
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                IssuerSigningKey = GetSecurityKey(configuration),
            };
        

        public string GenerateJwt(Guid userId, string userName, string email, string address) //-->LoggedInUser user
        {
            var securityKey = GetSecurityKey(_configuration);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var issuer = _configuration["Jwt:Issuer"];

            var expireInMinutes = Convert.ToInt32(_configuration["Jwt:ExpireInMinute"]);

            Claim[] claims = [
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()), //-->user.Id
                new Claim(ClaimTypes.Name, userName), //-->user.Name
                new Claim(ClaimTypes.Email, email),   //-->user.Email
                new Claim(ClaimTypes.StreetAddress, address),   //-->user.Address
                ];

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "*",
                claims: [],
                expires: DateTime.Now.AddMinutes(expireInMinutes),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);  
            
            return jwt;
        }

        public static SymmetricSecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secretKey = configuration["Jwt:SecretKey"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

            return securityKey;
        }
    }
}
