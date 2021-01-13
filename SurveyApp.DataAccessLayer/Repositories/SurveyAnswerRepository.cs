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
    public class SurveyAnswerRepository : BaseRepository<SurveyAnswer>, ISurveyAnswerRepository, IScopedDependency
    {
        public SurveyAnswerRepository(SurveyAppDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task AddAsync(SurveyAnswer surveyAnswer, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.UserId == surveyAnswer.UserId
                                                        && p.QuestionId == surveyAnswer.QuestionId
                                                        && p.OfferedAnswerId == surveyAnswer.OfferedAnswerId
                                                        && p.IsDelete == false);

            var notExists = await TableNoTracking.AnyAsync(p => p.UserId == surveyAnswer.UserId
                                                        && p.QuestionId == surveyAnswer.QuestionId
                                                        && p.OfferedAnswerId == null
                                                        && p.IsDelete == false);
            if (exists)
                throw new BadRequestException(" شما قبلا به این سوال پاسخ داده اید");

            if (notExists)
                throw new BadRequestException(" پاسخ سوال نمی تواند خالی باشد");

            await base.AddAsync(surveyAnswer, cancellationToken);

        }




    }
}