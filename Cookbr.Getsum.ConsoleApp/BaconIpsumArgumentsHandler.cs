using System.Threading;
using System.Threading.Tasks;

namespace Cookbr.Getsum.ConsoleApp
{
	public class BaconIpsumArgumentsHandler : ArgumentsHandler<BaconIpsumArguments>
	{
		public override Task<ArgumentsHandlerResponse> Handle(BaconIpsumArguments arguments, CancellationToken cancellationToken)
		{
			ArgumentsHandlerResponse response = new ArgumentsHandlerResponse<string>(nameof(BaconIpsumArguments));
			return Task.FromResult(response);
		}
	}
}