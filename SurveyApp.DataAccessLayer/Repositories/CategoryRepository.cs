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
    public class CategoryRepository : BaseRepository<SurveyCategory>, IScopedDependency, ICategoryRepository
    {
        public CategoryRepository(SurveyAppDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task AddAsync(SurveyCategory surveyCategory, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.SubNameCategory == surveyCategory.SubNameCategory);
            if (exists)
                throw new BadRequestException("دسته بندی تکراری است");
            await base.AddAsync(surveyCategory, cancellationToken);

        }




    }
}