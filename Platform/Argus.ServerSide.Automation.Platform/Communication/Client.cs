using Argus.ServerSide.Automation.Model.Platform.Client;
using Argus.ServerSide.Automation.Model.Platform.Communication;

using RestSharp;

namespace Argus.ServerSide.Automation.Platform.Communication
{
	public class Client(
	  RestClient restClient) : IClient
	{
		private RestClient _restClient = restClient;
		public async Task<ClientResponse> ExecuteAsync(
			ClientRequest request)
		{
			if (_restClient.Options.BaseUrl is null)
			{
				throw new ArgumentException("Base uri was not set.");
			}

			var response = await _restClient.ExecuteAsync(request);
			ClientResponse clientResponse;
			try
			{
				clientResponse = new ClientResponse
				{
					Content = response.Content,
					ContentType = response.ContentType,
					StatusCode = response.StatusCode,
					ResponseUri = response.ResponseUri.AbsoluteUri,
					Request = (ClientRequest)response.Request,
					RawBytes = response.RawBytes
				};
			}
			catch (Exception ex)
			{
				throw new OperationCanceledException($"The send API request returns exception. " +
													 $"\n\t\t\tMessage: [{ex.Message}], " +
													 $"\n\t\t\tSource: [{ex.Message}], " +
													 $"\n\t\t\tResponse status code: [{response.StatusCode}]," +
													 $"\n\t\t\tContent: [{response.Content}]," +
													 $"\n\t\t\tError Message: [{response.ErrorMessage}].");
			}
			return clientResponse;
		}

		public void SetBaseUri(string baseUrl)
		{
			_restClient = new RestClient(new RestClientOptions(baseUrl));
		}

		public void AddBearerHeader(string token)
		{
			restClient.AddDefaultHeader("Authorization", $"Bearer {token}");
		}
	}
}
