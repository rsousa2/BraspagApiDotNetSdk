namespace BraspagApiDotNetSdk.Contracts
{
	public class Sale : BaseResponse
	{
		public string MerchantOrderId { get; set; }

		public Customer Customer { get; set; }

		public Payment Payment { get; set; }
	}
}
