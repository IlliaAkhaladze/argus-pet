using Argus.ServerSide.Automation.Model.Platform.Client;
using Argus.ServerSide.Automation.Model.Platform.Communication;
using Argus.ServerSide.Automation.Platform.Extensions;

using RestSharp;

namespace Argus.ServerSide.Automation.Platform.Client
{
	public abstract class ApiClientBase(
		IClient client) : IApiClient
	{
		private readonly IClient _client = client;

		public async Task<T1> ExecutePostAsync<T1, T2>(
			string endpoint, T2 body)
			where T1 : class
			where T2 : class
		{
			var request = CreateRequest(endpoint, Method.Post, body);
			var response = await _client.ExecuteAsync(request);

			return response.GetModel<T1>();
		}

		public async Task<ClientResponse> ExecutePostAsync<T1>(
			string endpoint,
			T1 body)
		   where T1 : class
		{
			var request = CreateRequest(endpoint, Method.Post, body);
			var response = await _client.ExecuteAsync(request);

			return response;
		}

		public async Task<T1> ExecuteGetAsync<T1>(
			string endpoint)
			where T1 : class
		{
			var request = CreateRequest<ClientRequest>(endpoint, Method.Get, null);
			var response = await _client.ExecuteAsync(request);

			return response.GetModel<T1>();
		}

		protected async Task<ClientResponse> ExecuteDeleteAsync(
			string endpoint,
			string accessToken = null)
		{
			var request = new ClientRequest(endpoint, Method.Delete);

			return await _client.ExecuteAsync(request);
		}

		protected async Task<ClientResponse> ExecuteGetAsync(
			string uri)
		{
			var request = new ClientRequest(uri, Method.Get);

			ClientResponse response = await _client.ExecuteAsync(request);

			if(!response.IsSuccessfulStatusCode())
			{
				response = await _client.ExecuteAsync(request);
			}

			return response;
		}

		protected virtual ClientRequest CreateRequest<T>(
			string endpoint,
			Method method,
			T body)
		{
			var restRequest = new ClientRequest(endpoint, method);
			if (body != null)
			{
				restRequest.AddBody(body);
			}

			return restRequest;
		}

		public async Task<ClientResponse> ExecuteAsync(
		  ClientRequest clientRequest)
		{
			var response = await _client.ExecuteAsync(clientRequest);

			return response;
		}
	}
}
