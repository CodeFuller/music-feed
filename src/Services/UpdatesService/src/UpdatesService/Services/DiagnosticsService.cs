using System.Diagnostics;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using UpdatesService.Grpc;

namespace UpdatesService.Services
{
	internal class DiagnosticsService : UpdatesDiagnosticsService.UpdatesDiagnosticsServiceBase
	{
		public override Task<UpdatesDiagnosticsResponse> GetDiagnostics(Empty request, ServerCallContext context)
		{
			var diagnostics = new UpdatesDiagnosticsResponse
			{
				Version = GetApplicationVersion(),
			};

			return Task.FromResult(diagnostics);
		}

		private static string GetApplicationVersion()
		{
			var assembly = typeof(Program).Assembly.Location;
			var versionInfo = FileVersionInfo.GetVersionInfo(assembly);
			return versionInfo.ProductVersion;
		}
	}
}
