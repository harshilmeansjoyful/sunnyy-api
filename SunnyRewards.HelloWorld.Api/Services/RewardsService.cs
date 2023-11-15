using SunnyRewards.HelloWorld.Common.Services;
using SunnyRewards.HelloWorld.Api.Helpers.Interfaces;
using SunnyRewards.HelloWorld.Api.Services.Interfaces;

namespace SunnyRewards.HelloWorld.Api.Services
{

    /// <summary>
    /// 
    /// </summary>
    public class RewardsService : BaseService, IRewardsService
    {
        private readonly IRewardsHelper _rewardsHelper;
        private readonly ILogger<RewardsService> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rewardsHelper"></param>
        /// <param name="logger"></param>
        public RewardsService(IRewardsHelper rewardsHelper, ILogger<RewardsService> logger)
        {
            _logger = logger;
            _rewardsHelper = rewardsHelper;
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
                return await _rewardsHelper.GetRewardList();
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
