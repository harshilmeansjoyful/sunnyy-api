using SunnyRewards.HelloWorld.Common.Models;

namespace SunnyRewards.HelloWorld.Api.Models
{
    public class RewardsModel: BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int DeptNo { get; set; }
    }
}
