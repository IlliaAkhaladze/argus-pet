using NUnit.Framework;

namespace Argus.ServerSide.Automation.NUnit.Tests.Hooks;

[SetUpFixture]
public class SetupFixture
{

	[OneTimeSetUp]
	public void OneTimeSetUp()
	{
	}

	[OneTimeTearDown]
	public void OneTimeTearDown()
	{
	}
}
