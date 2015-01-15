using BraspagApiDotNetSdk.Contracts;
using System;

namespace BraspagApiDotNetSdk.Tests.Helpers
{
	public static class MerchantAuthenticationHelper
	{
		public static MerchantAuthentication CreateMerchantAuthentication()
		{
			return new MerchantAuthentication
			{
				MerchantId = Guid.NewGuid(),
				MerchantKey = Guid.NewGuid().ToString()
			};
		}
	}
}
