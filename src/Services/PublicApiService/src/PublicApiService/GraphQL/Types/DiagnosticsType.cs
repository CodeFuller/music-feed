using GraphQL.Types;
using PublicApiService.Models;

namespace PublicApiService.GraphQL.Types
{
	public class DiagnosticsType : ObjectGraphType<DiagnosticsModel>
	{
		public DiagnosticsType()
		{
			Field("version", x => x.Version, nullable: true);
			Field<SettingsType>("settings", resolve: context => context.Source.Settings);
		}
	}
}
