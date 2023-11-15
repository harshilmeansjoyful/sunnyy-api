using Microsoft.AspNetCore.Mvc;
using SunnyRewards.HelloWorld.Api.Services.Interfaces;

namespace SunnyRewards.HelloWorld.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly ILogger<RewardsController> _logger;
        private readonly IRewardsService _rewardsService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="rewardsService"></param>
        public RewardsController(ILogger<RewardsController> logger)
        {
            _logger = logger;
            
        }

        /// <summary>
        /// Method get sub category and Questionnaires detail
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRewardList()
        {
            try
            {


                _logger.LogInformation($"GetRewardList - Enter");

                //var rewardsList = await _rewardsService.GetRewardList();
                //return rewardsList != null ? Ok(rewardsList) : NotFound();
                var result =  new List<int>() { 1, 2, 3, 4 };
                return Ok( result );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetRewardList - Error");
                throw;
            }
            finally
            {
                _logger.LogInformation($"GetRewardList - Exit");
            }
        }
    }
}