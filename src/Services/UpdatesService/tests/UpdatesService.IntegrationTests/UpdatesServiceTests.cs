using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UpdatesService.Grpc;

namespace UpdatesService.IntegrationTests
{
	[TestClass]
	public class UpdatesServiceTests
	{
		[TestMethod]
		public async Task GetNewReleases_ReturnsCorrectData()
		{
			// Arrange

			var expectedData = new NewReleasesResponse
			{
				NewReleases =
				{
					new MusicRelease
					{
						Id = "1",
						Year = 2000,
						Title = "Don't Give Me Names",
					},

					new MusicRelease
					{
						Id = "2",
						Year = 2009,
						Title = "Shallow Life",
					},

					new MusicRelease
					{
						Id = "3",
						Year = 1998,
						Title = "How To Measure A Planet",
					},
				},
			};

			var request = new NewReleasesRequest
			{
				UserId = "TestUser",
			};

			using var factory = new CustomWebApplicationFactory();
			using var channel = factory.CreateGrpcChannel();
			var client = new Grpc.UpdatesService.UpdatesServiceClient(channel);

			// Act

			var response = await client.GetNewReleasesAsync(request);

			// Assert

			response.Should().BeEquivalentTo(expectedData);
		}
	}
}
