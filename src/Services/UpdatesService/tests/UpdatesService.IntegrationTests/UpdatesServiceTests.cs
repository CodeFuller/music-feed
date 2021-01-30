using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UpdatesService.Grpc;

namespace UpdatesService.IntegrationTests
{
	[TestClass]
	public class UpdatesServiceTests
	{
		[TestMethod]
		public async Task TestMethod()
		{
			// Arrange

			var request = new HelloRequest
			{
				Name = "CodeFuller",
			};

			using var factory = new CustomWebApplicationFactory();
			using var channel = factory.CreateGrpcChannel();
			var client = new Grpc.UpdatesService.UpdatesServiceClient(channel);

			// Act

			var reply = await client.SayHelloAsync(request);

			// Assert

			Assert.AreEqual("Hello CodeFuller", reply.Message);
		}
	}
}
