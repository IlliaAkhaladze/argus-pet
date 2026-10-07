using RestSharp;

namespace Argus.ServerSide.Automation.Model.Platform.Client;

public class ClientRequest(string uri, Method method) 
	: RestRequest(uri, method)
{
}
