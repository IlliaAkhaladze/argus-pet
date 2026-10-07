using Argus.ServerSide.Automation.Model.Domain.Pet;

using Bogus;

namespace Argus.ServerSide.Automation.TestData.Storages.Pet
{
	public static class PetCreationStorage
	{
		public static Dictionary<string, PetRequest> Values =>
			new()
			{
				{ "New", GetCreationPet() }
			};

		private static PetRequest GetCreationPet() =>
			new Faker<PetRequest>()
				.RuleFor(u => u.Category, PetCategoriesStorage.New)
				.RuleFor(u => u.Name, Guid.NewGuid().ToString("N"));
	}
}
