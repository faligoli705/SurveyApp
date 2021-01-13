

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class JwtService : IJwtService, IScopedDependency
    {
        private readonly SiteSetting _siteSetting;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<Users> signInManager;

        public JwtService(IOptionsSnapshot<SiteSetting> settings, SignInManager<Users> signInManager)
        {
            _siteSetting = settings.Value;
            this.signInManager = signInManager;
        }

        public async Task<AccessToken> GenerateAsync(Users user)
        {

            var secretKey = Encoding.UTF8.GetBytes("jwtSettings:SecretKey");
            var encryptionKey = Encoding.UTF8.GetBytes("jwtSettings:EncryptKey");

            //var secretKey = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey); // longer that 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            //var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.EncryptKey); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionKey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = await _getClaimsAsync(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "MyWebsite",
                Audience = "MyWebsite",
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(0),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

            return new AccessToken(securityToken);
        }

        private async Task<IEnumerable<Claim>> _getClaimsAsync(Users user)
        {
            var result = await signInManager.ClaimsFactory.CreateAsync(user);
            //add custom claims
            var list = new List<Claim>(result.Claims);
            list.Add(new Claim(ClaimTypes.MobilePhone, "09123456987")); 

            return list;
        }
    }
}