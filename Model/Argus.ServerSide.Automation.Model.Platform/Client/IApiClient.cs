namespace Argus.ServerSide.Automation.Model.Platform.Client
{
	public interface IApiClient
	{
		Task<T1> ExecutePostAsync<T1, T2>(string uri, T2 body)
			where T1 : class
			where T2 : class;
		Task<ClientResponse> ExecutePostAsync<T1>(string uri, T1 body)
			where T1 : class;
		Task<T1> ExecuteGetAsync<T1>(string uri)
			where T1 : class;
		Task<ClientResponse> ExecuteAsync(ClientRequest clientRequest);
	}
}
