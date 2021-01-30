using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using UpdatesService.Grpc;

namespace UpdatesService.Services
{
	internal class UpdatesService : Grpc.UpdatesService.UpdatesServiceBase
	{
		public override Task<NewReleasesResponse> GetNewReleases(NewReleasesRequest request, ServerCallContext context)
		{
			var response = new NewReleasesResponse
			{
				NewReleases =
				{
					new List<MusicRelease>
					{
						new()
						{
							Id = "1",
							Year = 2000,
							Title = "Don't Give Me Names",
						},

						new()
						{
							Id = "2",
							Year = 2009,
							Title = "Shallow Life",
						},

						new()
						{
							Id = "3",
							Year = 1998,
							Title = "How To Measure A Planet",
						},
					},
				},
			};

			return Task.FromResult(response);
		}
	}
}
