using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Cookbr.Getsum.ConsoleApp
{
	public class BaconIpsumHandler : IRequestHandler<BaconIpsumArgs, HandlerResponse>
	{
		public Task<HandlerResponse> Handle(BaconIpsumArgs request, CancellationToken cancellationToken)
		{
			HandlerResponse response = new HandlerResponse<string>(nameof(BaconIpsumArgs));
			return Task.FromResult(response);
		}
	}
}