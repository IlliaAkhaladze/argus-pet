using System.Text.RegularExpressions;

namespace Argus.ServerSide.Automation.NUnit.Tests.Hooks;

public class Bool
{
	private static readonly List<BoolMatch> Matches =
	  [
		new BoolMatch { Positive = "^open(?>ed)?$", Negative = "^close(?>d)?$" },
		new BoolMatch { Positive = "^check(?>ed)?$", Negative = "^uncheck(?>ed)?$" },
		new BoolMatch { Positive = "yes", Negative = "no" },
		new BoolMatch { Positive = "true", Negative = "false" },
		new BoolMatch { Positive = "on", Negative = "off" },
		new BoolMatch { Positive = "displayed", Negative = "not displayed" },
		new BoolMatch { Positive = "^enable(?>d)?$", Negative = "^disable(?>d)?$" },
		new BoolMatch { Positive = "appears", Negative = "does not appear" },
		new BoolMatch { Positive = "^released$", Negative = "^(?>not |un)released$" },
		new BoolMatch { Positive = "available", Negative = "not available" },
		new BoolMatch { Positive = "has", Negative = "has not" },
		new BoolMatch { Positive = "is", Negative = "is not" },
		new BoolMatch { Positive = "confirmed", Negative = "not confirmed" },
		new BoolMatch { Positive = "turn on", Negative = "turn off" },
		new BoolMatch { Positive = "see", Negative = "not see" },
		new BoolMatch { Positive = "as", Negative = "as not" },
		new BoolMatch { Positive = "Present", Negative = "Not Present" },
		new BoolMatch { Positive = "unlocked", Negative = "locked" },
		new BoolMatch { Positive = "selected", Negative = "not selected" },
		new BoolMatch { Positive = "selected", Negative = "deselected" },
		new BoolMatch { Positive = "select", Negative = "not select" },
		new BoolMatch { Positive = "marked", Negative = "not marked" },
		new BoolMatch { Positive = "permitted", Negative = "not permitted" },
		new BoolMatch { Positive = "active", Negative = "inactive" },
		new BoolMatch { Positive = "enabled", Negative = "disabled" },
		new BoolMatch { Positive = "emergencyOrIcu", Negative = "normal" },
	  ];

	private bool Value { get; set; }

	public static bool Parse(string value)
	{
		var result = new Bool();
		foreach (var match in Matches)
		{
			if (match.TryParse(value, ref result))
			{
				return result.Value;
			}
		}

		throw new InvalidCastException($"Can not cast {value} value to Bool");
	}

	private sealed class BoolMatch
	{
		public string Positive { private get; set; }

		public string Negative { private get; set; }

		public bool TryParse(string value, ref Bool result)
		{
			if (Regex.IsMatch(value, Positive, RegexOptions.IgnoreCase))
			{
				result.Value = true;
				return true;
			}

			if (Regex.IsMatch(value, Negative, RegexOptions.IgnoreCase))
			{
				result.Value = false;
				return true;
			}

			result.Value = false;
			return false;
		}
	}
}
