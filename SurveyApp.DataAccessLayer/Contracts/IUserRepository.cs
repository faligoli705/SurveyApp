using SurveyApp.DomainClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer.Contracts
{
    public interface IUserRepository : ISurveyAppRepository<Users>
    {
        Task<Users> GetByUserAndPass(string username, string password, CancellationToken cancellationToken);

        Task AddAsync(Users user, string password, CancellationToken cancellationToken);
        Task UpdateSecurityStampAsync(Users user, CancellationToken cancellationToken);
        Task UpdateLastLoginDateAsync(Users user, CancellationToken cancellationToken);
    }
}
