using System;

namespace BraspagApiDotNetSdk.Contracts
{
	public class MerchantAuthentication
	{
		public Guid MerchantId { get; set; }
		public string MerchantKey { get; set; }
	}
}
