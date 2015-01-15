using BraspagApiDotNetSdk.Contracts;

namespace BraspagApiDotNetSdk.Tests.Helpers
{
	public static class CaptureTransationHelper
	{
		public static CaptureRequest CreateValidCaptureRequest()
		{
			return new CaptureRequest
			{
				Amount = 15057,
				ServiceTaxAmount = 0
			};
		}
	}
}
