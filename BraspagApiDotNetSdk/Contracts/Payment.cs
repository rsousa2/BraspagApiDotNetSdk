using BraspagApiDotNetSdk.Contracts.Enum;
using System;
using System.Collections.Generic;

using BraspagApiDotNetSdk.Services;

using Newtonsoft.Json;

namespace BraspagApiDotNetSdk.Contracts
{
    [JsonConverter(typeof(PaymentConverter))]
	public class Payment
	{
		public Payment()
		{
			Country = "BRA";
			Currency = "BRL";
		}

		public Guid PaymentId { get; set; }

		public string Type { get; set; }

		public long Amount { get; set; }

		public long? CapturedAmount { get; set; }

		public long? VoidedAmount { get; set; }

		public string Currency { get; set; }

		public string Country { get; set; }

		public CarrierEnum Provider { get; set; }

		public PaymentCredentials Credentials { get; set; }

		public string ReturnUrl { get; set; }

		public List<ExtraData> ExtraDataCollection { get; set; }

		public byte ReasonCode { get; set; }

		public string ReasonMessage { get; set; }

        public string ProviderReturnCode { get; set; }

        public string ProviderReturnMessage { get; set; }

		public byte Status { get; set; }

		public List<Link> Links { get; set; } 

	}
}
