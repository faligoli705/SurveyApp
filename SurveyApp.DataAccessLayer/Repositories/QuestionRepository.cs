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
    public class QuestionRepository : BaseRepository<SurveyQuestions>, IQuestionRepository, IScopedDependency
    {
        public QuestionRepository(SurveyAppDbContext dbContext)
            : base(dbContext)
        {
        }


        public async Task AddAsync(SurveyQuestions surveyQuestion,  CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.QuestionText == surveyQuestion.QuestionText);
            if (exists)
                throw new BadRequestException("سوال تکراری است");

         var userCount= TableNoTracking.Where(q => q.Users.Id == surveyQuestion.UsersId && q.IsDelete==false).Count();
            if(userCount==10)
                throw new BadRequestException("شما نمی توانید بیشتر از 10 سوال ایجاد کنید. لطفا یکی از سوالها را حذف کنید");

            await base.AddAsync(surveyQuestion, cancellationToken);

        }
    }
}