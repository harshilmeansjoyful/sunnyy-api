using FluentNHibernate.Mapping;

namespace SunnyRewards.HelloWorld.Common.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseMapping<T> : ClassMap<T> where T : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public void AddBaseColumnMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Identity();
        }
    }
}
