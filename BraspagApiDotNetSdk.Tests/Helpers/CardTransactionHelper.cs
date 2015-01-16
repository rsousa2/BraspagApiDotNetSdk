using System;
using System.Collections.Generic;
using BraspagApiDotNetSdk.Contracts;
using BraspagApiDotNetSdk.Contracts.Enum;
using BraspagApiDotNetSdk.Contracts.Payments;

namespace BraspagApiDotNetSdk.Tests.Helpers
{
	public static class CardTransactionHelper
    {
        public static CreditCardPayment CreateCreditCardPaymentRequest()
        {
            return new CreditCardPayment
            {
                Amount = 15057,
                CreditCard = new Card
                {
                    Holder = "Teste T T Testando",
                    CardNumber = "4532117080573700",
                    ExpirationDate = "12/2015",
                    Brand = BrandEnum.Master
                },
                Installments = 3,
                Capture = false,
                Authenticate = false,
                Carrier = CarrierEnum.Simulado,
                ExtraDataCollection = new List<ExtraData>
                {
                    new ExtraData()
                    {
                        Name = "isso e um teste",
                        Value = "teste"
                    }
                }
            };
        }

		public static Payment CreateCreditCardPaymentResponse()
		{
			var paymentId = Guid.NewGuid();
			return new Payment
			{
				Amount = 15057,
				CapturedAmount = null,
				Credentials = null,
				Carrier = CarrierEnum.Simulado,
				ExtraDataCollection = new List<ExtraData>
                {
                    new ExtraData()
                    {
                        Name = "isso e um teste",
                        Value = "teste"
                    }
                },
				PaymentId = paymentId,
				ReasonCode = 0,
				ReasonMessage = "Successful",
				ReturnUrl = null,
				VoidedAmount = null,
				Status = 1,
				Type = "CreditCard",
				Links = new List<Link>
				{
					new Link
					{
						  Href = "https://apisandbox.braspag.com.br/v1/sales/" + paymentId,
						  Method = "GET",
						  Rel = "self"
					},
					new Link
					{
						Href = "https://apisandbox.braspag.com.br/v1/sales/" + paymentId + "capture",
						Method = "PUT",
						Rel = "capture"
					},
					new Link
					{
						Href = "https://apisandbox.braspag.com.br/v1/sales/" + paymentId + "void",
						Method = "PUT",
						Rel = "void"
					}
				}
			};
		}

		public static DebitCardPayment CreateDebitCardPaymentRequest()
		{
			return new DebitCardPayment
			{
				Amount = 15057,
				DebitCard = new Card()
				{
					Holder = "Teste T T Testando",
					CardNumber = "4532117080573700",
					ExpirationDate = "12/2015",
					Brand = BrandEnum.Master
				},
				Carrier = CarrierEnum.Cielo,
				ExtraDataCollection = new List<ExtraData>
                {
                    new ExtraData()
                    {
                        Name = "isso e um teste",
                        Value = "teste"
                    }
                }
			};
		}

		public static Payment CreateDebitCardPaymentResponse()
		{
			var paymentId = Guid.NewGuid();
			return new Payment
			{
				Amount = 15057,
				CapturedAmount = null,
				Credentials = null,
				Carrier = CarrierEnum.Cielo,
				PaymentId = paymentId,
				ReasonCode = 4,
				ReasonMessage = "Waiting",
				ReturnUrl = null,
				VoidedAmount = null,
				Status = 0,
				Links = new List<Link>
				{
					new Link
					{
						  Href = "http://www.pagador.com.br/v1/sales/" + paymentId,
						  Method = "GET",
						  Rel = "self"
					}
				}
			};
		}
    }
}
