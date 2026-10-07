using Argus.ServerSide.Automation.Model.Platform.Client;

using Newtonsoft.Json;

using RestSharp;

namespace Argus.ServerSide.Automation.Platform.Extensions
{
	public static class ClientExtensions
	{
		public static T GetModel<T>(
			this ClientResponse response,
			bool parseOnlySuccessStatus = true)
		{
			ArgumentNullException.ThrowIfNull(response);

			if (parseOnlySuccessStatus && !response.IsSuccessfulStatusCode())
			{
				throw new InvalidOperationException(
					$"Can't get model from failed response, " +
					$"Status Code: [{response.StatusCode}], " +
					$"Response: [{response.Content}].");
			}

			return JsonConvert.DeserializeObject<T>(response.Content);
		}

		public static bool IsSuccessfulStatusCode(
			this ClientResponse response) =>
			(int)response.StatusCode < 300 && (int)response.StatusCode >= 200;

		public static ClientRequest AddAuthorizationHeader(
			this ClientRequest request,
			string accessToken)
		{
			request.AddHeader("Authorization", accessToken);

			return request;
		}

	}
}
