using System;
using System.Collections.Generic;
using BraspagApiDotNetSdk.Contracts;
using BraspagApiDotNetSdk.Contracts.Enum;
using BraspagApiDotNetSdk.Contracts.Payments;

namespace BraspagApiDotNetSdk.Tests.Helpers
{
    public static class BoletoTransactionHelper
    {
        public static BoletoPayment BoletoTransactionRequest()
        {
            var boletoTransaction = new BoletoPayment
            {
	            Amount = 15057,
				Carrier = CarrierEnum.Bradesco
            };

            return boletoTransaction;
        }

		public static BoletoPayment BoletoTransactionResponse()
		{
			var paymentId = Guid.NewGuid();

			var boletoTransaction = new BoletoPayment
			{
				Amount = 15057,
				Carrier = CarrierEnum.Bradesco,
				PaymentId = paymentId,
				ReasonCode = 0,
				Type = "Boleto",
				ReasonMessage = "Successful",
				Status = 1,
				Links = new List<Link>
				{
					new Link
					{
						  Href = "https://apisandbox.braspag.com.br/v1/sales/" + paymentId,
						  Method = "GET",
						  Rel = "self"
					}
				}
			};

			return boletoTransaction;
		}
    }
}
