using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Common
{
    public interface IEntity
    {
    }
    public interface IEntity<TKey> : IEntity
    {
        [Key]
        TKey Id { get; set; }

         DateTime? CreateDate { get; set; }
         DateTime? DeleteDate { get; set; }
         DateTime? UpdateDate { get; set; }
         bool IsDelete { get; set; }
    }
    public abstract class BaseEntities<Tkey> : IEntity
    {
        [Key]        
        public Tkey Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDelete { get; set; }
    }
    public abstract class BaseEntities : BaseEntities<int>
    {
    }
}
