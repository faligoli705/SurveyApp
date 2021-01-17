
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer
{
    public class AuthenRepository : IAuthenRepository
    {
        SurveyAppDbContext _context;
        //IMemoryCache _cache;
        ILogger<AuthenRepository> _logger;
        public AuthenRepository(SurveyAppDbContext context, ILogger<AuthenRepository> logger)
        {
            _context = context;
            //_cache = cache;
            _logger = logger;
        }

        public Task<Users> ListUserLogin(string userName, string userPassword)
        {
            _logger.LogError("ارتباط با جدول customer");
            var passwordHash = SecurityHelper.GetSha256Hash(userPassword);
            return _context.Users.Where(p =>!p.IsDelete && p.UserName == userName && p.PasswordHash == passwordHash).SingleOrDefaultAsync();

         

        }
    }
}
