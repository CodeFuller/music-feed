using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UpdatesService.IntegrationTests
{
	[TestClass]
	public class DiagnosticsServiceTests
	{
		[TestMethod]
		public async Task GetDiagnostics_ReturnsCorrectData()
		{
			// Arrange

			using var factory = new CustomWebApplicationFactory();
			var client = factory.CreateDiagnosticsServiceClient();

			// Act

			var response = await client.GetDiagnosticsAsync();

			// Assert

			// We do not compare version, because
			// 1. It changes often, which will require frequent update of test data.
			// 2. CI updates version with build number, so we can not predict it in test code.
			response.Version.Should().NotBeNullOrEmpty();
		}
	}
}
