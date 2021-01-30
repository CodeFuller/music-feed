using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PublicApiService.Interfaces;
using PublicApiService.Models;

namespace PublicApiService.Internal
{
	public class NewReleasesProvider : INewReleasesProvider
	{
		public Task<IReadOnlyCollection<ReleaseModel>> GetNewReleases(CancellationToken cancellationToken)
		{
			var releases = new[]
			{
				new ReleaseModel
				{
					Id = new IdModel("1"),
					Year = 2000,
					Title = "Don't Give Me Names",
				},

				new ReleaseModel
				{
					Id = new IdModel("2"),
					Year = 2009,
					Title = "Shallow Life",
				},

				new ReleaseModel
				{
					Id = new IdModel("3"),
					Year = 1998,
					Title = "How To Measure A Planet",
				},
			};

			return Task.FromResult<IReadOnlyCollection<ReleaseModel>>(releases);
		}
	}
}
