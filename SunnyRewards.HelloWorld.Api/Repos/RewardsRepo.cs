using SunnyRewards.HelloWorld.Common.Repos;
using SunnyRewards.HelloWorld.Api.Models;
using SunnyRewards.HelloWorld.Api.Repos.Interfaces;

namespace SunnyRewards.HelloWorld.Api.Repos
{
    /// <summary>
    /// 
    /// </summary>
    public class RewardsRepo : BaseRepo<RewardsModel>, IRewardsRepo
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="logger"></param>
        public RewardsRepo(NHibernate.ISession session, ILogger<BaseRepo<RewardsModel>> logger) : base(session, logger)
        {
        }
    }
}
