using System;
using Microsoft.Extensions.DependencyInjection;

namespace mavvm
{
	public static class MavvmContainer
	{
		public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// REgisters the service provider and creates a dependency scope
        /// </summary>
        /// <param name="sp"></param>
        public static void RegisterServiceProvider(IServiceProvider sp)
        {
            var scope = sp.CreateScope();
            ServiceProvider = scope.ServiceProvider;
        }
    }
}

