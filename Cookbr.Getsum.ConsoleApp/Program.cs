using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cookbr.Getsum.ConsoleApp
{
	class Program
	{
		static async Task<int> Main(string[] args)
		{
			var serviceProvider = CreateServiceProvider();

			var argumentsParser = serviceProvider.GetService<IArgumentsParser>();
			if (!argumentsParser.TryParse(args, out var arguments))
				return 1;

			var argumentsHandlerType = typeof(IArgumentsHandler<>).MakeGenericType(arguments.GetType());
			var argumentsHandler = (IArgumentsHandler)serviceProvider.GetService(argumentsHandlerType);
			var argumentsHandlerResponse = await argumentsHandler.Handle(arguments);

			Console.WriteLine(argumentsHandlerResponse);
			return 0;
		}

		private static IServiceProvider CreateServiceProvider()
		{
			var services = new ServiceCollection()
				.AddLogging(builder => builder.AddConsole())
				.Scan(scan => scan
					.FromAssembliesOf(typeof(IArgumentsHandler<>))
					.AddClasses(classes => classes.AssignableTo(typeof(IArgumentsHandler<>)))
					.AsImplementedInterfaces()
				);

			return services
				.AddSingleton<IArgumentsParser>(_ => new ArgumentsParser(services))
				.BuildServiceProvider();
		}
	}
}