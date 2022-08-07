using FindJob;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;

namespace FindJobTests.TestModels.TestSevices
{
	public abstract class BaseInitTest
    {
        protected DependencyResolverHelper _serviceProvider;

        [SetUp]
        public void InitServiceProvider()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            _serviceProvider = new DependencyResolverHelper(webHost);
        }
    }
}