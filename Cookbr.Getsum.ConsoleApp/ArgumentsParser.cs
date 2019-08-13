using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbr.Getsum.ConsoleApp
{
	public interface IArgumentsParser
	{
		bool TryParse(IEnumerable<string> args, out IArguments arguments);
	}

	public class ArgumentsParser : IArgumentsParser
	{
		private readonly IServiceCollection services;

		public ArgumentsParser(IServiceCollection services)
		{
			this.services = services;
		}

		public bool TryParse(IEnumerable<string> args, out IArguments arguments)
		{
			arguments = default;
			var parserResult = Parser.Default.ParseArguments(args, GetKnownArgumentsTypes());
			if (parserResult is Parsed<object> parsed)
				arguments = parsed.Value as IArguments;
			return arguments != null;
		}

		private Type[] GetKnownArgumentsTypes()
		{
			return services.Where(DescriptorDescribesArgumentsHandler).Select(ArgumentsTypeFromArgumentsHandlerType).ToArray();

			bool DescriptorDescribesArgumentsHandler(ServiceDescriptor descriptor)
				=> descriptor.ServiceType.IsGenericType && descriptor.ServiceType.GetGenericTypeDefinition() == typeof(IArgumentsHandler<>);

			Type ArgumentsTypeFromArgumentsHandlerType(ServiceDescriptor descriptor) => descriptor.ServiceType.GetGenericArguments()[0];
		}
	}
}