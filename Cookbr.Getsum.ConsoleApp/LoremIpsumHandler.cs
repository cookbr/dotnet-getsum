using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Cookbr.Getsum.ConsoleApp
{
	public class LoremIpsumHandler : IRequestHandler<LoremIpsumArgs, HandlerResponse>
	{
		public Task<HandlerResponse> Handle(LoremIpsumArgs request, CancellationToken cancellationToken)
		{
			HandlerResponse response = new HandlerResponse<string>(nameof(LoremIpsumArgs));
			return Task.FromResult(response);
		}
	}
}