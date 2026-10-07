using Argus.ServerSide.Automation.Bootstrap;

using Autofac;

using Microsoft.Extensions.Configuration;

using Reqnroll.Autofac;

namespace Argus.ServerSide.Automation.NUnit.Tests.Hooks;

public class TestDependencies
{
	[ScenarioDependencies]
	public static ContainerBuilder CreateContainerBuilder()
	{
		var builder = new Bootstraper();
		builder.ConfigureModules(GetConfiguration());
		builder.Builder.RegisterTypes(
			[.. typeof(TestDependencies)
				.Assembly.GetTypes()
				.Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))])
			.InstancePerLifetimeScope();

		return builder.Builder;
	}

	private static IConfigurationBuilder GetConfiguration()
	{
		var ciEnv = Environment.GetEnvironmentVariable("testrun.environment");
		var val = string.IsNullOrEmpty(ciEnv) ? "int" : ciEnv;

		return new ConfigurationBuilder()
				.AddJsonFile($"env.{val}.json", optional: true, reloadOnChange: true);
	}
}
