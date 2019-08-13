using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cookbr.Getsum.ConsoleApp
{
	public abstract class HandlerResponse
	{
	}

	public sealed class HandlerResponse<T> : HandlerResponse
	{
		private readonly T response;

		public HandlerResponse(T response)
		{
			this.response = response;
		}

		public override string ToString()
		{
			if (response is string s)
				return s;

			return JsonConvert.SerializeObject(response, new JsonSerializerSettings
			{
				ContractResolver = new DefaultContractResolver
				{
					NamingStrategy = new CamelCaseNamingStrategy()
				},
				Formatting = Formatting.Indented
			});
		}
	}
}