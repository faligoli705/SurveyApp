using Microsoft.EntityFrameworkCore;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using SurveyApp.Infrastucture.Execptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer.Repositories
{
    public class OfferedAnswerRepository : BaseRepository<OfferedAnswers>, IOfferedAnswerRepository, IScopedDependency
    {
        public OfferedAnswerRepository(SurveyAppDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task AddAsync(OfferedAnswers offeredAnswers, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.OfferedAnswerText == offeredAnswers.OfferedAnswerText);
            if (exists)
                throw new BadRequestException("جواب تکراری است");
            await base.AddAsync(offeredAnswers, cancellationToken);

        }
    }
}