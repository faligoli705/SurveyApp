using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveyApp.DomainClass.Common;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture.Utilities;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyApp.DataAccessLayer
{
    public class SurveyAppDbContext : IdentityDbContext<Users, Roles,Guid>
    {
        public SurveyAppDbContext(DbContextOptions options)
            :base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Get Assembly Entities 
            var entitiesAssembly = typeof(IEntity).Assembly;
            
            // Automatically add models to the database (Data Annotation)
            modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            //modelBuilder.Entity<SurveyCategory>(entity => { entity.HasKey(e => e.Id); entity.ToTable("SurveyCategory"); });
            /*
             * If you use DataLayerAccess 
             * var entitiesAssembly = typeof(SurveyAppDbContext).Assembly;
            */
            // Automatically add models to the database (Flunet Web API)
            modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);

            // The Parrent will not be removed until the Chile are removed
            //تا دادهای فرزند حذف نشود دادهای در جدول پدر حذف نخواهد شد
            modelBuilder.AddRestrictDeleteBehaviorConvention();

            //Change Gui Normal to Gui NEWSEQUENTIALID
            modelBuilder.AddSequentialGuidForIdConvention();

            /*برای فیلد دیگه اگر نیاز به 
             * Guid 
             *  بود میتوانیم ازین مدل استفاده کنیم و فیلد مورد نظر رو 
             *  تبدیل به 
             * Guid‌کنیم
            */
            //modelBuilder.Entity<SurveyCategory>().Property(p => p.Id).HasDefultValueSql("NEWSEQUENTIALID");

            //جمع بندی نام جداول
            modelBuilder.AddPluralizingTableNameConvention();
        }

    }
}
