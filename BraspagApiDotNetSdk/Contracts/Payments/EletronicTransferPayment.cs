namespace BraspagApiDotNetSdk.Contracts.Payments
{
	public class EletronicTransferPayment : Payment
	{
		public EletronicTransferPayment()
        {
            Type = "EletronicTransfer";
        }

        public string Url { get; set; }

	}
}
