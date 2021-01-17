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

            var userCount = TableNoTracking.Where(q => q.SurveyQuestionsAnswerId == offeredAnswers.SurveyQuestionsAnswerId && q.IsDelete == false).Count();
            if (userCount == 5)
                throw new BadRequestException("شما نمیتوانید برای یک سوال بیش از 5 جواب داشته باشید");


            await base.AddAsync(offeredAnswers, cancellationToken);

        }
        public async Task DeleteAsync(OfferedAnswers offeredAnswers, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.Id == offeredAnswers.Id && p.IsDelete==true);
            if (exists)
                throw new BadRequestException("قبلا حذف شده است");
            offeredAnswers.IsDelete = true;
            offeredAnswers.DeleteDate = DateTime.Now;
            await base.DeleteAsync(offeredAnswers, cancellationToken);
        }

    }
}