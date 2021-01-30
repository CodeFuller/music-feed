using System;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PublicApiService.IntegrationTests
{
	public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
	{
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
