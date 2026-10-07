using Argus.ServerSide.Automation.Domain.Autofac;
using Argus.ServerSide.Automation.Platform.Autofac;
using Argus.ServerSide.Automation.Platform.Configuration.Environment;

using Autofac;

using Microsoft.Extensions.Configuration;

namespace Argus.ServerSide.Automation.Bootstrap
{
	public class Bootstraper
	{
		private ContainerBuilder _builder;

		public ContainerBuilder Builder => _builder ??= new ContainerBuilder();

		public void ConfigureModules(IConfigurationBuilder configurationBuilder)
		{
			var configurationRoot = configurationBuilder.Build();
			// Configurations
			Builder.RegisterModule<ServerSidePlatformModule>();
			Builder.RegisterModule<AutomationDomainModule>();

			Builder.Register<IEnvironmentConfiguration>(context => configurationRoot.Get<EnvironmentConfiguration>())
				.SingleInstance();
		}
	}
}
