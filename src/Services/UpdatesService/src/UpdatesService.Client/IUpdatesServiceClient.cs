using System;
using System.Threading;
using UpdatesService.Grpc;

using grpc = Grpc.Core;

namespace UpdatesService.Client
{
	/// <summary>
	/// Client for UpdateService.
	/// </summary>
	public interface IUpdatesServiceClient
	{
		/// <summary>
		/// Returns new music releases for requested user.
		/// </summary>
		/// <param name="request">The request to send to the server.</param>
		/// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
		/// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
		/// <param name="cancellationToken">An optional token for canceling the call.</param>
		/// <returns>The call object.</returns>
		public grpc::AsyncUnaryCall<NewReleasesResponse> GetNewReleasesAsync(NewReleasesRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default);
	}
}
