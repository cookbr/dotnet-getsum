using CommandLine;
using MediatR;

namespace Cookbr.Getsum.ConsoleApp
{
	[Verb("skate", HelpText = "Skate Ipsum <http://skateipsum.com>")]
	public class SkateIpsumArgs : IRequest<HandlerResponse>
	{
	}
}