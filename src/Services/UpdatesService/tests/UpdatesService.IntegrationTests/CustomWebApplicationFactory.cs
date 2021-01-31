using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using UpdatesService.Client;

namespace UpdatesService.IntegrationTests
{
	public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
	{
		private ServiceProvider ServiceProvider { get; set; }

		public IUpdatesServiceClient CreateServiceClient()
		{
			var services = new ServiceCollection();

			var httpClient = CreateClient();

			services.AddUpdatesServiceClient(factoryOptions =>
			{
				factoryOptions.Address = httpClient.BaseAddress;
				factoryOptions.ChannelOptionsActions.Add(channelOptions => channelOptions.HttpClient = httpClient);
			});

			ServiceProvider = services.BuildServiceProvider();

			return ServiceProvider.GetRequiredService<IUpdatesServiceClient>();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
			{
				ServiceProvider?.Dispose();
			}
		}
	}
}
