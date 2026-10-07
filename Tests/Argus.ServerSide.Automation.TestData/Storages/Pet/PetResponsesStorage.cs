using Argus.ServerSide.Automation.Model.Domain.Pet;

using Bogus;

namespace Argus.ServerSide.Automation.TestData.Storages.Pet
{
	public static class PetResponsesStorage
	{
		public static Dictionary<string, PetResponse> PetResponses =>
			new()
			{
				{ "Default", Default }
			};

		private static PetResponse Default =>
			new Faker<PetResponse>()
				.RuleFor(u => u.Id, "2")
				.RuleFor(u => u.Name, "Doggie")
				.RuleFor(u => u.Status, "available")
				.RuleFor(u => u.PhotoUrls, [])
				.RuleFor(u => u.Tags, []);
	}
}
