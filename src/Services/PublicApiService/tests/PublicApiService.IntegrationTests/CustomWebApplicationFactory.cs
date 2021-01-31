using System;
using System.Collections.Generic;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace PublicApiService.IntegrationTests
{
	public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			base.ConfigureWebHost(builder);

			builder.ConfigureAppConfiguration(configBuilder =>
			{
				configBuilder
					.AddInMemoryCollection(new[] { new KeyValuePair<string, string>("services:updatesServiceAddress", "http://localhost:8102/") });
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
