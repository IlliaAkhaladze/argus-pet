namespace Argus.ServerSide.Automation.Model.Domain.Pet
{
	public interface IPetContext
	{
		Task<PetResponse> GetPetByIdAsync(string petId);
		Task<ResponseMessage> GetPetByIdResponseAsync(string petId);
		Task<ResponseMessage> CreatePetResponseAsync(PetRequest petRequest);
		Task<ResponseMessage> DeletePetResponseAsync(string petId);
		Task<CreatePetResponse> CreatePetAsync(PetRequest petRequest);
	}
}
