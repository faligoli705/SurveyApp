using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DomainClass.Common
{
    public interface IEntity
    {
    }
    public abstract class BaseEntities<Tkey> : IEntity
    {
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
