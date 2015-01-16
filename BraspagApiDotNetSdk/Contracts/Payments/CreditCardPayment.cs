using System;
using System.Configuration;
using BraspagApiDotNetSdk.Contracts.Enum;

namespace BraspagApiDotNetSdk.Contracts.Payments
{
	public class CreditCardPayment : Payment
	{
		public CreditCardPayment()
		{
			Type = "CreditCard";
			Capture = Convert.ToBoolean(ConfigurationManager.AppSettings["braspagDefaultCapture"]);
			Authenticate = Convert.ToBoolean(ConfigurationManager.AppSettings["braspagDefaultAuthenticate"]);
			Interest = (InterestTypeEnum)System.Enum.Parse(typeof(InterestTypeEnum), ConfigurationManager.AppSettings["braspagDefaultInterest"]);
		}
		
		public long ServiceTaxAmount { get; set; }

		public short Installments { get; set; }

		public InterestTypeEnum Interest { get; set; }

		public bool Capture { get; set; }

		public bool Authenticate { get; set; }

		public Card CreditCard { get; set; }

		public string AuthenticationUrl { get; set; }

		public string ProofOfSale { get; set; }
		
		public string AcquirerTransactionId { get; set; }
		
		public string AuthorizationCode { get; set; }

		public string SoftDescriptor { get; set; }
	}
}
