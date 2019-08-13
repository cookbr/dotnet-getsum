using CommandLine;
using MediatR;

namespace Cookbr.Getsum.ConsoleApp
{
	[Verb("lorem", HelpText = "Loripsum <https://loripsum.net>")]
	public class LoremIpsumArgs : IRequest<HandlerResponse>
	{
	}
}