using System;
using Grpc.Net.ClientFactory;
using Microsoft.Extensions.DependencyInjection;
using UpdatesService.Grpc;

namespace UpdatesService.Client
{
	/// <summary>
	/// Extension methods for adding client to UpdatesService.
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// Adds services required for client to UpdatesService.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
		/// <param name="configureClient">A delegate that is used to configure the gRPC client.</param>
		/// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
		public static IServiceCollection AddUpdatesServiceClient(this IServiceCollection services, Action<GrpcClientFactoryOptions> configureClient)
		{
			services.AddGrpcClient<Grpc.UpdatesService.UpdatesServiceClient>(configureClient);
			services.AddGrpcClient<UpdatesDiagnosticsService.UpdatesDiagnosticsServiceClient>(configureClient);

			services.AddSingleton<IUpdatesServiceClient, Grpc.UpdatesService.UpdatesServiceClient>(sp => sp.GetRequiredService<Grpc.UpdatesService.UpdatesServiceClient>());
			services.AddSingleton<IUpdatesDiagnosticsServiceClient, UpdatesDiagnosticsService.UpdatesDiagnosticsServiceClient>(sp => sp.GetRequiredService<UpdatesDiagnosticsService.UpdatesDiagnosticsServiceClient>());

			return services;
		}
	}
}
