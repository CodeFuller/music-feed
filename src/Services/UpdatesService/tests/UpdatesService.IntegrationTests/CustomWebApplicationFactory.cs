using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc.Testing;

namespace UpdatesService.IntegrationTests
{
	public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
	{
		public GrpcChannel CreateGrpcChannel()
		{
			var httpClient = CreateClient();

			return GrpcChannel.ForAddress(httpClient.BaseAddress, new GrpcChannelOptions
			{
				HttpClient = httpClient,
			});
		}
	}
}
