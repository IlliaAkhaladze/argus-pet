using Argus.ServerSide.Automation.Model.Domain.Pet;

using Bogus;

namespace Argus.ServerSide.Automation.TestData.Storages.Pet
{
	public static class PetCategoriesStorage
	{
		public static Category DefaultCategory =>
			new Faker<Category>()
				.RuleFor(u => u.Id, 1)
				.RuleFor(u => u.Name, "cat1");

		public static Category New =>
			new Faker<Category>()
				.RuleFor(u => u.Id, new Bogus.Randomizer().Number(1 ,100))
				.RuleFor(u => u.Name, Guid.NewGuid().ToString("N"));

	}
}
