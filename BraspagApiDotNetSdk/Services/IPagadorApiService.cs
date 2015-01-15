using BraspagApiDotNetSdk.Contracts;
using System;

namespace BraspagApiDotNetSdk.Services
{
	public interface IPagadorApiService
	{
		Sale CreateSale(MerchantAuthentication merchantAuthentication, Sale sale);

		CaptureResponse Capture(Guid paymentId, MerchantAuthentication merchantAuthentication, CaptureRequest captureRequest);

		VoidResponse Void(Guid paymentId, MerchantAuthentication merchantAuthentication, int? amount);

		Sale Get(Guid paymentId, MerchantAuthentication merchantAuthentication);
	}
}
