using Argus.ServerSide.Automation.Model.Domain;
using Argus.ServerSide.Automation.Model.Domain.Pet;
using Argus.ServerSide.Automation.TestData.Storages.Pet;

using FluentAssertions;

namespace Argus.ServerSide.Automation.NUnit.Tests.Features
{
	[Binding, Scope(Feature = "Get Pet by Id")]
	public class GetPetDefinition(
		IPetContext petContext)
	{
		private readonly IPetContext _petContext = petContext;
		private PetResponse? _petResponse;
		private ResponseMessage? _responseMessage;

		[When(@"I receive get pet by id response")]
		public async Task GivenIReceiveGetPetByIdResponse()
		{
			_petResponse = await _petContext.GetPetByIdAsync("2");
		}

		[When(@"I receive get pet by id response with (.*) wrong id")]
		public async Task WhenIReceiveGetPetByIdResponseWithWrongId(string value)
		{
			_responseMessage = await _petContext.GetPetByIdResponseAsync(value);
		}

		[Then(@"I see (.*) response status code")]
		public void ThenISeeResponseStatusCode(string expectedStatusCode)
		{
			_responseMessage!.StatusCode.Should().Be(expectedStatusCode);
		}

		[Then(@"I see (.*) response")]
		public void ThenISeeResponse(string expectedErrorResponse)
		{
			_responseMessage!.Content.Should().Be(expectedErrorResponse);
		}

		[Then(@"I see returned pet details")]
		public void ThenISeeReturnedPetDetails()
		{
			var expectedResponse = PetResponsesStorage.PetResponses["Default"];
			_petResponse.Should().BeEquivalentTo(expectedResponse);
		}
	}
}
