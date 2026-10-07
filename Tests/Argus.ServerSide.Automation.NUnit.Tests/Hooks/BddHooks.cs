using Argus.ServerSide.Automation.Platform.Configuration.Environment;

using Autofac;

using NUnit.Framework;

using System.Collections;

namespace Argus.ServerSide.Automation.NUnit.Tests;

[Binding]
public class BddHooks(
	ScenarioContext scenarioContext,
	FeatureContext featureContext)
{
	private static ScenarioStepContext _stepContext;
	private static IContainer Container { get; set; }
	private static string _type = "";

	[BeforeTestRun]
	public static async Task BeforeTestRunAsync()
	{
		InitAutomationContainer();
		InitAutomationEnvironment();

		// ..
		await Task.Delay(100);
	}

	[BeforeFeature]
	public static void BeforeFeature()
	{
	}

	[BeforeScenario]
	public void BeforeScenario()
	{
		string featureName = $"{featureContext.FeatureInfo.Title}({featureContext.FeatureInfo.FolderPath})";
		string scenarioName = $"{scenarioContext.ScenarioInfo.Title}";

		Console.WriteLine($"[{featureName}\n{scenarioName}]");
	}

	[BeforeStep]
	public void BeforeStep()
	{
		Console.WriteLine("BeforeStepAsync");
		_stepContext = scenarioContext.StepContext;
		_type = _stepContext.StepInfo.StepInstance.Keyword.Trim();
	}

	[AfterStep]
	public void AfterStep()
	{
		Console.WriteLine("AfterStepAsync");

		if (scenarioContext.TestError == null)
		{
			Console.WriteLine($"[{_type} - {scenarioContext.StepContext.StepInfo.Text}]");
		}
	}

	[AfterScenario]
	public async Task AfterScenarioAsync()
	{
		await Task.Delay(100);

		if (scenarioContext.TestError != null)
		{
			string message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
			  ? ""
			  : $"{TestContext.CurrentContext.Result.Message}";
			string stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
			  ? ""
			  : $"{TestContext.CurrentContext.Result.StackTrace}";

			Console.WriteLine(message);
		}

		scenarioContext?.Clear();

		Console.WriteLine("[AFTER_SCENARIO] is finished." +
								 $"\n\t\t\tScenarioName: [{scenarioContext?.ScenarioInfo.Title}]," +
								 $"\n\t\t\tTest EndTime: [{DateTime.UtcNow:G}]");
	}

	[AfterFeature]
	public static void AfterFeature()
	{
		Console.WriteLine("AfterFeatureAsync");
	}


	[AfterTestRun]
	public static void AfterTestRun()
	{
		Console.WriteLine("AfterTestRunAsync");
	}

	private static void InitAutomationContainer()
	{
		var containerBuilder = TestDependencies.CreateContainerBuilder();
		Container = containerBuilder.Build();
	}

	private static void InitAutomationEnvironment()
	{
		var environmentConfig = Container.Resolve<IEnvironmentConfiguration>();

		PrintEnvironmentVariable();
	}

	private static void PrintEnvironmentVariable()
	{
		var environmentVariables = Environment.GetEnvironmentVariables();
		foreach (DictionaryEntry variable in environmentVariables)
		{
			Console.WriteLine($"Key: [{variable.Key}], Value: [{variable.Value}].");
		}
	}
}
