using Newtonsoft.Json;

namespace ProductCatalog.UI.Services
{
	public class ServiceResponse<TKey>
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public TKey ResponseData { get; set; }
		public List<string> ErrorMessages { get; set; }
		public ServiceResponse(List<string> errorMessages, TKey data)
		{
			ResponseData = data;
			ErrorMessages = errorMessages;
		}
	}
}
