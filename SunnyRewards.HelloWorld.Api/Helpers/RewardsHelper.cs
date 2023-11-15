using SunnyRewards.HelloWorld.Common.Helpers;
using SunnyRewards.HelloWorld.Api.Helpers.Interfaces;
using SunnyRewards.HelloWorld.Api.Repos.Interfaces;
using SunnyRewards.HelloWorld.Api.Models;

namespace SunnyRewards.HelloWorld.Api.Helpers
{

    /// <summary>
    /// 
    /// </summary>
    public class RewardsHelper : BaseHelper, IRewardsHelper
    {
        private readonly IRewardsRepo _rewardsRepo;
        private readonly ILogger<RewardsHelper> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rewardsRepo"></param>
        /// <param name="logger"></param>
        public RewardsHelper(IRewardsRepo rewardsRepo, ILogger<RewardsHelper> logger)
        {
            _rewardsRepo = rewardsRepo;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<int>> GetRewardList()
        {
            try
            {
                _logger.LogInformation("GetRewardList -Enter");
               // var rewardLst = await _rewardsRepo.FindAllAsync();
                return  new List<int>() { 1,2,3,4};
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "GetRewardList -Error");
                throw;
            }
            finally
            {
                _logger.LogInformation("GetRewardList -Exit");
            }
        }
    }
}
