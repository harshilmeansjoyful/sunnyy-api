using SunnyRewards.HelloWorld.Common.Models;
using SunnyRewards.HelloWorld.Api.Models;

namespace SunnyRewards.HelloWorld.Api.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class RewardsModelMap : BaseMapping<RewardsModel>
    {
        /// <summary>
        /// 
        /// </summary>
        public RewardsModelMap()
        {
            Table("rewards");
            AddBaseColumnMap();
            Map(x => x.Name).Column("Name");
            Map(x => x.DeptNo).Column("DeptNo");
        }
    }
}
