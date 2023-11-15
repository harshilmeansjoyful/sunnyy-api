using Microsoft.Extensions.Configuration;
using SunnyRewards.HelloWorld.Common.Infrastructure.Interfaces;

namespace SunnyRewards.HelloWorld.Common.Infrastructure
{
    public class Runtime : IRuntime
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// will be initiaized using .net core dependency inection
        /// </summary>
        /// <param name="configuration"></param>
        public Runtime(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    }
}
