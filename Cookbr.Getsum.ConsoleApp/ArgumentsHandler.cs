using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbr.Getsum.ConsoleApp
{
	public abstract class ArgumentsHandler<T> : IArgumentsHandler<T> where T : IArguments
	{
		public abstract Task<ArgumentsHandlerResponse> Handle(T arguments, CancellationToken cancellationToken);

		public virtual Task<ArgumentsHandlerResponse> Handle(IArguments arguments, CancellationToken cancellationToken = default)
		{
			if (arguments == null)
				throw new ArgumentNullException(nameof(arguments));

			if (!(arguments is T handlerArguments))
				throw new NotSupportedException($"{arguments.GetType().Name} are not supported.");

			return Handle(handlerArguments, cancellationToken);
		}
	}
}