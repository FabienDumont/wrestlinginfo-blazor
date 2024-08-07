using System.Net;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api;

public class HttpTrigger {
	private readonly ILogger _logger;

	public HttpTrigger(ILoggerFactory loggerFactory) {
		_logger = loggerFactory.CreateLogger<HttpTrigger>();
	}

	[Function("Wrestlers")]
	public HttpResponseData GetWrestlers([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req) {
		List<Wrestler> result = [
			new Wrestler {
				Name = "John Cena",
				DateOfBirth = new DateOnly(1977, 4, 23)
			},
			new Wrestler {
				Name = "Randy Orton",
				DateOfBirth = new DateOnly(1980, 4, 1)
			}
		];

		HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
		ValueTask writeAsJsonAsync = response.WriteAsJsonAsync(result);

		return response;
	}
	
	[Function("Promotions")]
	public HttpResponseData GetPromotions([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req) {
		List<Promotion> result = [
			new Promotion {
				Name = "WWE",
				Description = "World Wrestling Entertainment (WWE) was founded in 1953 as Capitol Wrestling Corporation (CWC)."
			},
			new Promotion {
				Name = "AEW",
				Description = "All Elite Wrestling (AEW) was founded in 2019."
			},
		];

		HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
		ValueTask writeAsJsonAsync = response.WriteAsJsonAsync(result);

		return response;
	}
}