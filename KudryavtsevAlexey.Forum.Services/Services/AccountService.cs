using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly ForumDbContext _dbContext;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        private readonly string Issuer = string.Empty;

        private readonly string Audience = string.Empty;

        private readonly string SecretKey = string.Empty;

        public AccountService(ForumDbContext dbContext, UserManager<ApplicationUser> userManager, 
                            SignInManager<ApplicationUser> signInManager, IMapper mapper, IConfiguration configuration)
        {
            
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
            Issuer = _configuration["Authentication:JwtBearer:Issuer"];
            Audience = _configuration["Authentication:JwtBearer:Audience"];
            SecretKey = _configuration["Authentication:JwtBearer:SecretKey"];
        }

        private string GenerateToken(string userName, string userEmail)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Email, userEmail),
            };

            var key = Encoding.UTF8.GetBytes(SecretKey);

            var securityKey = new SymmetricSecurityKey(key);

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                Issuer,
                Audience,
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }

        public async Task Register(RegisterUserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);

            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Name == userDto.OrganizationName);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(userDto.OrganizationName);
            }

            user.Organization = organization;

            var result = await _userManager.CreateAsync(user, userDto.Password);
        }

        public async Task<string> SignIn(SignInUserDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);

            if (user is null)
            {
                throw new UserNotFoundException(userDto.Email);
            }

            var result = await _signInManager.PasswordSignInAsync(user, userDto.Password, false, false);

            var token = string.Empty;

            if (result.Succeeded)
            {
                token = GenerateToken(user.UserName, user.Email);

                await _signInManager.SignInAsync(user, false);
            }

            return token;
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Id == userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            await _userManager.DeleteAsync(user);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
