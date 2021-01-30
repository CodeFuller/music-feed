using System.Threading.Tasks;
using Grpc.Core;
using UpdatesService.Grpc;

namespace UpdatesService.Services
{
	internal class UpdatesService : Grpc.UpdatesService.UpdatesServiceBase
	{
		public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			return Task.FromResult(new HelloReply
			{
				Message = "Hello " + request.Name,
			});
		}
	}
}
