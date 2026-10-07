using Argus.ServerSide.Automation.Model.Domain;
using Argus.ServerSide.Automation.Model.Domain.Pet;
using Argus.ServerSide.Automation.Model.Platform.Communication;
using Argus.ServerSide.Automation.Platform.Client;
using Argus.ServerSide.Automation.Platform.Configuration.Environment;
using Argus.ServerSide.Automation.Platform.Extensions;

namespace Argus.ServerSide.Automation.Domain.Pet
{
	public class PetApiClient : ApiClientBase, IPetApiClient
	{
		public PetApiClient(
			IClient client,
			IEnvironmentConfiguration environmentConfiguration)
			: base(client)
		{
			client.SetBaseUri(environmentConfiguration.EnvironmentUri);
		}

		public async Task<PetResponse> GetPetByIdAsync(
			string petId)
		{
			var restResponse = await ExecuteGetAsync(
				$"/v2/pet/{petId}");

			return restResponse.GetModel<PetResponse>();
		}

		public async Task<ResponseMessage> GetPetByIdResponseAsync(
			string petId)
		{
			var restResponse = await ExecuteGetAsync(
				$"/v2/pet/{petId}");

			return new ResponseMessage
			{
				Content = restResponse.Content,
				StatusCode = restResponse.StatusCode.ToString()
			};
		}

		public async Task<ResponseMessage> CreatePetResponseAsync(
			PetRequest petRequest)
		{
			var restResponse = await ExecutePostAsync(
				"/v2/pet",
				petRequest);

			return new ResponseMessage
			{
				Content = restResponse.Content,
				StatusCode = restResponse.StatusCode.ToString()
			};
		}

		public async Task<ResponseMessage> DeletePetResponseAsync(
			string petId)
		{
			var restResponse = await ExecuteDeleteAsync(
				$"/v2/pet/{petId}");

			return new ResponseMessage
			{
				Content = restResponse.Content,
				StatusCode = restResponse.StatusCode.ToString()
			};
		}


		public async Task<CreatePetResponse> CreatePetAsync(
			PetRequest petRequest)
		{
			var restResponse = await ExecutePostAsync(
				"/v2/pet",
				petRequest);

			return restResponse.GetModel<CreatePetResponse>();
		}
	}
}
