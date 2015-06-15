namespace BraspagApiDotNetSdk.Contracts
{
	public class PaymentCredentials
	{
		public string Code { get; set; }
		public string Key { get; set; }
        public string Password { get; set; }
        public string Signature { get; set; }
        public string Username { get; set; }
	}
}
