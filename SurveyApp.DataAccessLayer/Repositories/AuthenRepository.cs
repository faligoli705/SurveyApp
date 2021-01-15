
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SurveyApp.DomainClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Users ListcustomersLogin(string userName, string userPassword)
        {
            _logger.LogError("ارتباط با جدول customer");
            return _context.Users.Where(x => !x.IsDelete
                 && x.UserName == userName
                && x.PasswordHash == userPassword
                ).SingleOrDefault();

        }
    }
}
