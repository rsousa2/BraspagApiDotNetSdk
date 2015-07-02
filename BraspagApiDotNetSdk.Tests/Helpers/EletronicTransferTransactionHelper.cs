using System;
using System.Collections.Generic;
using BraspagApiDotNetSdk.Contracts;
using BraspagApiDotNetSdk.Contracts.Enum;
using BraspagApiDotNetSdk.Contracts.Payments;

namespace BraspagApiDotNetSdk.Tests.Helpers
{
	public static class EletronicTransferTransactionHelper
	{
		public static EletronicTransferPayment EletronicTransferTransactionRequest()
		{
			return new EletronicTransferPayment
			{
				Type = "EletronicTransfer",
				Amount = 15700,
                Provider = ProviderEnum.Bradesco
			};
		}

		public static EletronicTransferPayment EletronicTransferTransactionResponse()
		{
			var paymentId = Guid.NewGuid();

			return new EletronicTransferPayment
			{
				Amount = 15700,
                Provider = ProviderEnum.Bradesco,
				Country = "BRA",
				Currency = "BRL",
				PaymentId = paymentId,
				ReasonCode = 0,
				Type = "EletronicTransfer",
				ReasonMessage = "Successful",
				Status = 0,
				Links = new List<Link>
				{
					new Link
					{
						  Href = "https://apisandbox.braspag.com.br/v2/sales/" + paymentId,
						  Method = "GET",
						  Rel = "self"
					}
				}
			};
		}
	}
}
