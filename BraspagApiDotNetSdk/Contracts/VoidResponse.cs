using System.Collections.Generic;

namespace BraspagApiDotNetSdk.Contracts
{
	public class VoidResponse : BaseResponse
	{
		public int Status { get; set; }
		public int ReasonCode { get; set; }
		public string ReasonMessage { get; set; }
        public string ProviderReturnCode { get; set; }
        public string ProviderReturnMessage { get; set; }

		public List<Link> Links { get; set; } 
	}
}
