using System;
using System.Threading;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using UpdatesService.Client;

namespace UpdatesService.Grpc
{
#pragma warning disable CA1724 // Type names should not match namespaces
	public static partial class UpdatesDiagnosticsService
#pragma warning restore CA1724 // Type names should not match namespaces
	{
#pragma warning disable CA1034 // Nested types should not be visible
		public partial class UpdatesDiagnosticsServiceClient : IUpdatesDiagnosticsServiceClient
#pragma warning restore CA1034 // Nested types should not be visible
		{
			/// <inheritdoc cref="IUpdatesDiagnosticsServiceClient.GetDiagnosticsAsync"/>
			public AsyncUnaryCall<UpdatesDiagnosticsResponse> GetDiagnosticsAsync(Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default)
			{
				return GetDiagnosticsAsync(new Empty(), headers, deadline, cancellationToken);
			}
		}
	}
}
