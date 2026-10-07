using Argus.ServerSide.Automation.Model.Domain;
using Argus.ServerSide.Automation.Model.Domain.Pet;
using Argus.ServerSide.Automation.TestData.Storages.Pet;

using FluentAssertions;

namespace Argus.ServerSide.Automation.NUnit.Tests.Features
{
	[Binding, Scope(Feature = "Post Pet")]
	public class PostPetDefinition(
		IPetContext petContext)
	{
		private readonly IPetContext _petContext = petContext;
		private ResponseMessage? _responseMessage;
		private CreatePetResponse? _createdPet;
		private PetRequest? _createDetails;

		[When(@"I send the pet creation request with empty model")]
		public async Task WhenISendThePetCreationRequestWithEmptyModel()
		{
			_createdPet = await _petContext.CreatePetAsync(
				new PetRequest());
		}

		[When(@"I send the pet creation request with null model")]
		public async Task WhenISendThePetCreationRequestWithNullModel()
		{
			_responseMessage = await _petContext.CreatePetResponseAsync(
				null);
		}

		[Then(@"I see '(.*)' status code request")]
		public void ThenISeeStatusCodeRequest(string expectedStatusCode)
		{
			_responseMessage!.StatusCode.Should().Be(expectedStatusCode);
		}

		[Then(@"I see created pet in the get response")]
		public async Task ThenISeeCreatedPet()
		{
			var actualGetResponse = await _petContext.GetPetByIdResponseAsync(
				_createdPet!.Id.ToString());
			actualGetResponse.Content.Should().NotBeNullOrEmpty();
		}

		[When("I create pet with {string} data")]
		public async Task WhenICreatePetWithData(string entityName)
		{
			_createDetails = PetCreationStorage.Values[entityName];
			_createdPet = await _petContext.CreatePetAsync(
				_createDetails);
		}

		[Then("I see that new pet has been created successfully")]
		public void ThenISeeThatNewPetHasBeenCreatedSuccessfully()
		{
			_createdPet!.Name.Should().Be(_createDetails!.Name);
			_createdPet!.Category.Should().BeEquivalentTo(_createDetails!.Category);
			_createdPet.Id.ToString().Should().NotBeNullOrEmpty();
			_createdPet.Status.Should().BeNull();
			_createdPet.PhotoUrls.Should().BeNull();
			_createdPet.Tags.Should().BeNull();
		}

	}
}
