using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbr.Getsum.ConsoleApp
{
	public interface IArgsParser
	{
		bool TryParse(IEnumerable<string> args, out IRequest<HandlerResponse> request);
	}

	public class ArgsParser : IArgsParser
	{
		private readonly IServiceCollection services;

		public ArgsParser(IServiceCollection services)
		{
			this.services = services;
		}

		public bool TryParse(IEnumerable<string> args, out IRequest<HandlerResponse> request)
		{
			request = default;
			var parserResult = Parser.Default.ParseArguments(args, GetKnownArgsTypes());
			if (parserResult is Parsed<object> parsed)
				request = parsed.Value as IRequest<HandlerResponse>;
			return request != null;
		}

		private Type[] GetKnownArgsTypes()
		{
			return services.Where(DescriptorDescribesRequestHandler).Select(RequestTypeFromHandlerDescriptor).ToArray();

			bool DescriptorDescribesRequestHandler(ServiceDescriptor descriptor)
				=> descriptor.ServiceType.IsGenericType && descriptor.ServiceType.GetGenericTypeDefinition() == typeof(IRequestHandler<,>);

			Type RequestTypeFromHandlerDescriptor(ServiceDescriptor descriptor) => descriptor.ServiceType.GetGenericArguments()[0];
		}
	}
}