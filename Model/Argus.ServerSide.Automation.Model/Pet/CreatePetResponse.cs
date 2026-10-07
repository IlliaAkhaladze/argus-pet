namespace Argus.ServerSide.Automation.Model.Domain.Pet
{
	public class CreatePetResponse
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Status { get; set; }
		public string[] PhotoUrls { get; set; }
		public Category Category { get; set; }
		public Tag[] Tags { get; set; }
	}
}
