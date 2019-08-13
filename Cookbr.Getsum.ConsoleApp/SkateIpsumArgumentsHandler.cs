using System.Threading;
using System.Threading.Tasks;

namespace Cookbr.Getsum.ConsoleApp
{
	public class SkateIpsumHandler : ArgumentsHandler<SkateIpsumArguments>
	{
		public override Task<ArgumentsHandlerResponse> Handle(SkateIpsumArguments arguments, CancellationToken cancellationToken)
		{
			ArgumentsHandlerResponse response = new ArgumentsHandlerResponse<string>(nameof(SkateIpsumArguments));
			return Task.FromResult(response);
		}
	}
}