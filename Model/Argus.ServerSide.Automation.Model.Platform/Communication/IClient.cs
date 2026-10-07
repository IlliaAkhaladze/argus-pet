using Argus.ServerSide.Automation.Model.Platform.Client;

namespace Argus.ServerSide.Automation.Model.Platform.Communication
{
	public interface IClient
	{
		Task<ClientResponse> ExecuteAsync(ClientRequest request);
		void SetBaseUri(string baseUri);
	}
}
