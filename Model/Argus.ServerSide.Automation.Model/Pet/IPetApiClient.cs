namespace Argus.ServerSide.Automation.Model.Domain.Pet
{
	public interface IPetApiClient
	{
		Task<PetResponse> GetPetByIdAsync(string petId);
		Task<ResponseMessage> GetPetByIdResponseAsync(string petId);
		Task<ResponseMessage> CreatePetResponseAsync(PetRequest petRequest);
		Task<CreatePetResponse> CreatePetAsync(PetRequest petRequest);
		Task<ResponseMessage> DeletePetResponseAsync(string petId);
	}
}
