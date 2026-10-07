using Argus.ServerSide.Automation.Model.Domain;
using Argus.ServerSide.Automation.Model.Domain.Pet;
using Argus.ServerSide.Automation.TestData.Storages.Pet;

using FluentAssertions;

namespace Argus.ServerSide.Automation.NUnit.Tests.Features
{
	[Binding, Scope(Feature = "Delete Pet")]
	public class PetDelete(
		IPetContext petContext)
	{
		private CreatePetResponse? _createdPet;
		private PetRequest? _createDetails;
		private ResponseMessage? _actualDeleteResponse;
		private string? _createdPetId;

		[Given("I have created pet entity")]
		public async Task GivenIHaveCreatedPetEntityAsync()
		{
			_createDetails = PetCreationStorage.Values["New"];
			_createdPet = await petContext.CreatePetAsync(
				_createDetails);
			_createdPetId = _createdPet!.Id.ToString();
		}

		[When("I delete the created pet entity")]
		public async Task WhenIDeleteTheCreatedPetEntityAsync()
		{
			_actualDeleteResponse = await petContext.DeletePetResponseAsync(
				_createdPetId);
		}

		[Then("I don't see newly created pet")]
		public async Task ThenIDoNotSeeNewlyCreatedPetAsync()
		{
			var acrualGetResponse = await petContext.GetPetByIdResponseAsync(
				_createdPetId.ToString());
			acrualGetResponse.StatusCode
				.Should()
				.Be("NotFound");
		}

		[Then("I see {string} response status of delete request")]
		public void ThenISeeResponseStatusOfDeleteRequest(
			string expectedStatusCode)
		{
			_actualDeleteResponse!.StatusCode
				.Should()
				.Be(expectedStatusCode);
		}

		[When("I delete not exists pet by {string} id value")]
		public async Task WhenIDeleteNotExistsPetByIdValueAsync(
			string placeHolder)
		{
			var value = placeHolder.Replace("GUID", Guid.NewGuid().ToString("N"));
			_actualDeleteResponse = await petContext.DeletePetResponseAsync(value);
		}

		[When("I delete not exists pet by null id value")]
		public async Task WhenIDeleteNotExistsPetByNullIdValueAsync()
		{
			_actualDeleteResponse = await petContext.DeletePetResponseAsync(null);
		}

	}
}
