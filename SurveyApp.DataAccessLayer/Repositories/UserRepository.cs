
using Microsoft.EntityFrameworkCore;
using SurveyApp.Infrastucture.Execptions;
using SurveyApp.DataAccessLayer.Contracts;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using SurveyApp.Infrastucture.Utilities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer
{
    public class UserRepository : SurveyAppRepository<Users>, IUserRepository, IScopedDependency
    {
        public UserRepository(SurveyAppDbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<Users> GetByUserAndPass(string username, string password, CancellationToken cancellationToken)
        {
            var passwordHash = SecurityHelper.GetSha256Hash(password);
            return Table.Where(p => p.UserName == username && p.PasswordHash == passwordHash).SingleOrDefaultAsync(cancellationToken);
        }

        public Task UpdateSecurityStampAsync(Users user, CancellationToken cancellationToken)
        {
            //user.SecurityStamp = Guid.NewGuid();
            return UpdateAsync(user, cancellationToken);
        }

        //public override void Update(User entity, bool saveNow = true)
        //{
        //    entity.SecurityStamp = Guid.NewGuid();
        //    base.Update(entity, saveNow);
        //}

        public Task UpdateLastLoginDateAsync(Users user, CancellationToken cancellationToken)
        {
            user.LastLoginDate = DateTimeOffset.Now;
            return UpdateAsync(user, cancellationToken);
        }

        public async Task AddAsync(Users user, string password, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.UserName == user.UserName);
            if (exists)
                throw new BadRequestException("نام کاربری تکراری است");

            var passwordHash = SecurityHelper.GetSha256Hash(password);
            user.PasswordHash = passwordHash;
            await base.AddAsync(user, cancellationToken);
        }
    }
}