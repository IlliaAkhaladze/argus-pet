namespace Argus.ServerSide.Automation.NUnit.Tests.Hooks;

[Binding]
public class StepsTransformation
{
	[StepArgumentTransformation]
	public static string[] TransformToListOfString(string commaSeparatedList)
	{
		return [.. commaSeparatedList.Split(";").Select(e => e.Trim())];
	}

	[StepArgumentTransformation]
	public static bool StringToBool(string value)
	{
		return Bool.Parse(value);
	}
}
