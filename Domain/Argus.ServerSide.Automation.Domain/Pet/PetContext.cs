using Argus.ServerSide.Automation.Model.Domain;
using Argus.ServerSide.Automation.Model.Domain.Pet;

namespace Argus.ServerSide.Automation.Domain.Pet
{
	public class PetContext(
		IPetApiClient petApiClient) : IPetContext
	{
		private readonly IPetApiClient _petApiClient = petApiClient;

		public async Task<PetResponse> GetPetByIdAsync(
			string petId)
		{
			return await _petApiClient.GetPetByIdAsync(petId);
		}

		public async Task<ResponseMessage> GetPetByIdResponseAsync(
			string petId)
		{
			return await _petApiClient.GetPetByIdResponseAsync(petId);
		}

		public async Task<ResponseMessage> CreatePetResponseAsync(
			PetRequest petRequest)
		{
			return await _petApiClient.CreatePetResponseAsync(petRequest);
		}

		public async Task<ResponseMessage> DeletePetResponseAsync(
			string petId)
		{
			return await _petApiClient.DeletePetResponseAsync(petId);
		}

		public async Task<CreatePetResponse> CreatePetAsync(
			PetRequest petRequest)
		{
			return await _petApiClient.CreatePetAsync(petRequest);
		}
	}
}
