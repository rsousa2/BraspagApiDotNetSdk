using System.Configuration;
using BraspagApiDotNetSdk.Contracts.Enum;
using System;
using System.Collections.Generic;

namespace BraspagApiDotNetSdk.Contracts
{
	public class Payment
	{
		public Payment()
		{
			Country = ConfigurationManager.AppSettings["braspagDefaultCountry"];
			Currency = ConfigurationManager.AppSettings["braspagDefaultCurrency"];
		}

		public Guid PaymentId { get; set; }

		public string Type { get; set; }

		public long Amount { get; set; }

		public long? CapturedAmount { get; set; }

		public long? VoidedAmount { get; set; }

		public string Currency { get; set; }

		public string Country { get; set; }

		public CarrierEnum Carrier { get; set; }

		public PaymentCredentials Credentials { get; set; }

		public string ReturnUrl { get; set; }

		public List<ExtraData> ExtraDataCollection { get; set; }

		public byte ReasonCode { get; set; }

		public string ReasonMessage { get; set; }

		public byte Status { get; set; }

		public List<Link> Links { get; set; } 

	}
}
