using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.ServiceResponses
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
