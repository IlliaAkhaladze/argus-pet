using Argus.ServerSide.Automation.Domain.Pet;
using Argus.ServerSide.Automation.Model.Domain.Pet;

using Autofac;

namespace Argus.ServerSide.Automation.Domain.Autofac
{
	public class AutomationDomainModule : Module
	{
		protected override void Load(
			ContainerBuilder containerBuilder)
		{
			base.Load(containerBuilder);

			// Api Clients
			containerBuilder.RegisterType<PetApiClient>().As<IPetApiClient>().SingleInstance();

			// Logic
			containerBuilder.RegisterType<PetContext>().As<IPetContext>().SingleInstance();
		}
	}
}
