using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
//using Microsoft.Extensions.Logging;

namespace ApiIsolated;

public class ScriptureFunction
{
	/*
public static class ScriptureFunction
{
	private static readonly ILogger _logger;

	public ScriptureFunction(ILoggerFactory loggerFactory)
	{
		_logger = loggerFactory.CreateLogger<ScriptureFunction>();
	}
	*/
	[Function("ScriptureFunction")]
	public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
	{
		//_logger.LogInformation("C# HTTP trigger function processed a request.");

		var response = req.CreateResponse(HttpStatusCode.OK);
		response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
		response.WriteString("Shalom to Azure Functions!");
		return response;
	}

}
