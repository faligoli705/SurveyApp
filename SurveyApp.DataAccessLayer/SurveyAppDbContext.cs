using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
            : base(options)
        {

        }

        #region Authomatic Add Table to Database
        /// <summary>
        /// Get Assembly Entities
        /// Automatically add models to the database (Data Annotation)
        /// modelBuilder.Entity<SurveyCategory>(entity => { entity.HasKey(e => e.Id); entity.ToTable("SurveyCategory"); });
        /*
         * If you use DataLayerAccess 
         * var entitiesAssembly = typeof(SurveyAppDbContext).Assembly;
        */
        // Automatically add models to the database (Flunet Web API)
        // The Parrent will not be removed until the Chile are removed
        //تا دادهای فرزند حذف نشود دادهای در جدول پدر حذف نخواهد شد
        //Change Gui Normal to Gui NEWSEQUENTIALID
        /*برای فیلد دیگه اگر نیاز به 
            * Guid 
            *  بود میتوانیم ازین مدل استفاده کنیم و فیلد مورد نظر رو 
            *  تبدیل به 
            * Guid‌کنیم
           */
        //modelBuilder.Entity<SurveyCategory>().Property(p => p.Id).HasDefultValueSql("NEWSEQUENTIALID");
        //جمع بندی نام جداول
        /// </summary>
        /// <param name="modelBuilder"></param>
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
        #endregion

        #region Change Carachter Arabic to Farsi
        /// <summary>
        /// cheked Carachter Fa or Arabic And change to Fa
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();  
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _cleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess); 
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(cancellationToken);    
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken); 
        }
        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }

            }
        }

        #endregion
    }
}
