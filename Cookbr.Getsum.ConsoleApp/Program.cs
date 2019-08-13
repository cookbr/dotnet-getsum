using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cookbr.Getsum.ConsoleApp
{
	class Program
	{
		static async Task<int> Main(string[] args)
		{
			var serviceProvider = CreateServiceProvider();

			var parser = serviceProvider.GetService<IArgsParser>();
			if (!parser.TryParse(args, out var request))
				return 1;

			var mediator = serviceProvider.GetService<IMediator>();
			Console.WriteLine(await mediator.Send(request));
			return 0;
		}

		private static IServiceProvider CreateServiceProvider()
		{
			var services = new ServiceCollection()
				.AddLogging(builder => builder.AddConsole())
				.AddMediatR(typeof(Program).Assembly);

			return services
				.AddSingleton<IArgsParser>(_ => new ArgsParser(services))
				.BuildServiceProvider();
		}
	}
}