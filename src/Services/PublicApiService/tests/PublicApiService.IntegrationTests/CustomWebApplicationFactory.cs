using System;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PublicApiService.IntegrationTests
{
	public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			base.ConfigureWebHost(builder);

			builder.ConfigureLogging(loggingBuilder =>
			{
				loggingBuilder.ClearProviders();
				loggingBuilder.AddConsole();
			});

			builder.ConfigureServices(services =>
			{
				services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
			});
		}

		public IGraphQLClient CreateGraphQLClient()
		{
			var httpClient = CreateClient();

			var clientOptions = new GraphQLHttpClientOptions
			{
				EndPoint = new Uri(httpClient.BaseAddress, "graphql"),
			};

			return new GraphQLHttpClient(clientOptions, new NewtonsoftJsonSerializer(), httpClient);
		}
	}
}
