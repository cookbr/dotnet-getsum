using System.Threading;
using System.Threading.Tasks;

namespace Cookbr.Getsum.ConsoleApp
{
	public class LoripsumHandler : ArgumentsHandler<LoripsumArguments>
	{
		public override Task<ArgumentsHandlerResponse> Handle(LoripsumArguments arguments, CancellationToken cancellationToken)
		{
			ArgumentsHandlerResponse response = new ArgumentsHandlerResponse<string>(nameof(LoripsumArguments));
			return Task.FromResult(response);
		}
	}
}