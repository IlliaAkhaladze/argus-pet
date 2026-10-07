using System.Net;

namespace Argus.ServerSide.Automation.Model.Platform.Client;

public class ClientResponse
{
	public string Content { get; set; }
	public string ContentType { get; set; }
	public HttpStatusCode StatusCode { get; set; }
	public string ResponseUri { get; set; }
	public ClientRequest Request { get; set; }
	public byte[] RawBytes { get; set; }
}
