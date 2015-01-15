using System.Collections.Generic;
using System.Net;

namespace BraspagApiDotNetSdk.Contracts
{
	public class BaseResponse
	{
		public HttpStatusCode HttpStatus { get; set; }

		public List<Error> ErrorDataCollection { get; set; }
	}
}
