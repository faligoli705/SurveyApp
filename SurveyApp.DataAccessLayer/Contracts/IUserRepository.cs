using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer.Contracts
{
    public interface IUserRepository : IBaseRepository<Users>,IScopedDependency
    {
        Task<Users> GetByUserAndPass(string username, string password, CancellationToken cancellationToken);

        Task AddAsync(Users user, string password, CancellationToken cancellationToken);
        Task UpdateSecurityStampAsync(Users user, CancellationToken cancellationToken);
        Task UpdateLastLoginDateAsync(Users user, CancellationToken cancellationToken);
    }
}
