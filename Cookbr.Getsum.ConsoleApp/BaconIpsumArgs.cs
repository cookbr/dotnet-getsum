using CommandLine;
using MediatR;

namespace Cookbr.Getsum.ConsoleApp
{
	[Verb("bacon", HelpText = "Bacon Ipsum <https://baconipsum.com>")]
	public class BaconIpsumArgs : IRequest<HandlerResponse>
	{
	}
}