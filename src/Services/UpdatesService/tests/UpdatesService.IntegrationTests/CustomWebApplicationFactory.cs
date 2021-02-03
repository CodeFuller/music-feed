using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using UpdatesService.Client;

namespace UpdatesService.IntegrationTests
{
	public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
	{
		private ServiceProvider ServiceProvider { get; set; }

		public IUpdatesServiceClient CreateUpdatesServiceClient()
		{
			InitializeServiceProvider();

			return ServiceProvider.GetRequiredService<IUpdatesServiceClient>();
		}

		public IUpdatesDiagnosticsServiceClient CreateDiagnosticsServiceClient()
		{
			InitializeServiceProvider();

			return ServiceProvider.GetRequiredService<IUpdatesDiagnosticsServiceClient>();
		}

		private void InitializeServiceProvider()
		{
			if (ServiceProvider != null)
			{
				return;
			}

			var services = new ServiceCollection();

			var httpClient = CreateClient();

			services.AddUpdatesServiceClient(factoryOptions =>
			{
				factoryOptions.Address = httpClient.BaseAddress;
				factoryOptions.ChannelOptionsActions.Add(channelOptions => channelOptions.HttpClient = httpClient);
			});

			ServiceProvider = services.BuildServiceProvider();
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
