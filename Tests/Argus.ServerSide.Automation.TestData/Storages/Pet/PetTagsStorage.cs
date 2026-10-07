using Argus.ServerSide.Automation.Model.Domain.Pet;

using Bogus;

namespace Argus.ServerSide.Automation.TestData.Storages.Pet
{
	public static class PetTagsStorage
	{
		public static Tag Default =>
			new Faker<Tag>()
				.RuleFor(u => u.Name, "naughty1")
				.RuleFor(u => u.Id, "1");

		public static Tag Tag1 =>
			new Faker<Tag>()
				.RuleFor(u => u.Name, "naughty1")
				.RuleFor(u => u.Id, "1");

		public static Tag Tag2 =>
			new Faker<Tag>()
				.RuleFor(u => u.Name, "nice1")
				.RuleFor(u => u.Id, "2");
	}
}
