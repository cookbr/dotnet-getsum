using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Cookbr.Getsum.ConsoleApp
{
	public class SkateIpsumHandler : IRequestHandler<SkateIpsumArgs, HandlerResponse>
	{
		public Task<HandlerResponse> Handle(SkateIpsumArgs request, CancellationToken cancellationToken)
		{
			HandlerResponse response = new HandlerResponse<string>(nameof(SkateIpsumArgs));
			return Task.FromResult(response);
		}
	}
}