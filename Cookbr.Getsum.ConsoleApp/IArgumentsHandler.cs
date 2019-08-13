using System.Threading;
using System.Threading.Tasks;

namespace Cookbr.Getsum.ConsoleApp
{
	public interface IArgumentsHandler
	{
		Task<ArgumentsHandlerResponse> Handle(IArguments arguments, CancellationToken cancellationToken = default);
	}

	public interface IArgumentsHandler<in T> : IArgumentsHandler where T : IArguments
	{
		Task<ArgumentsHandlerResponse> Handle(T arguments, CancellationToken cancellationToken = default);
	}
}