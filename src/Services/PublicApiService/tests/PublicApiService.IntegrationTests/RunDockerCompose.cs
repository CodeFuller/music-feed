using System;
using System.Collections.Generic;
using Ductus.FluentDocker.Model.Compose;
using Ductus.FluentDocker.Services;
using Ductus.FluentDocker.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PublicApiService.IntegrationTests
{
	[TestClass]
	public static class RunDockerCompose
	{
		private static DockerComposeCompositeService DockerComposeService { get; set; }

		[AssemblyInitialize]
#pragma warning disable CA1801 // Review unused parameters
		public static void DockerComposeUp(TestContext context)
#pragma warning restore CA1801 // Review unused parameters
		{
			Console.WriteLine("Executing docker-compose up ...");

			if (DockerComposeService != null)
			{
				throw new InvalidOperationException("docker-compose up was already executed");
			}

			DockerComposeService = new DockerComposeCompositeService(new Hosts().Native(), new DockerComposeConfig
			{
				ComposeFilePath = new List<string> { "docker-compose.yml" },
				ForceRecreate = false,
				RemoveOrphans = true,
				StopOnDispose = true,
			});

			DockerComposeService.Start();

			Console.WriteLine("docker-compose up was executed successfully");
		}

		[AssemblyCleanup]
		public static void DockerComposeDown()
		{
			Console.WriteLine("Executing docker-compose down ...");

			if (DockerComposeService == null)
			{
				return;
			}

			DockerComposeService.Stop();
			DockerComposeService.Dispose();
			DockerComposeService = null;

			Console.WriteLine("docker-compose down was executed successfully");
		}
	}
}
