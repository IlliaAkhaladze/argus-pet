using Argus.ServerSide.Automation.Model.Platform.Communication;

using Autofac;

namespace Argus.ServerSide.Automation.Platform.Autofac
{
	public class ServerSidePlatformModule : Module
	{
		protected override void Load(
			ContainerBuilder builder)
		{
			base.Load( builder );
			builder.RegisterType<Communication.Client>().As<IClient>();
			builder.RegisterType<RestSharp.RestClient>().AsSelf();
		}
	}
}
