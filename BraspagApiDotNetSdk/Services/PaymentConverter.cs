using System;

using BraspagApiDotNetSdk.Contracts;
using BraspagApiDotNetSdk.Contracts.Payments;

using Newtonsoft.Json.Linq;

namespace BraspagApiDotNetSdk.Services
{
    public class PaymentConverter : JsonCreationConverter<Payment>
    {
        public override Payment Create(Type objectType, JObject jObject)
        {
            var type = jObject.GetValue("type", StringComparison.OrdinalIgnoreCase);

            if (type == null) return null;

            switch (type.ToString().ToLower())
            {
                case "creditcard":
                    return new CreditCardPayment();
                case "debitcard":
                    return new DebitCardPayment();
                case "boleto":
                    return new BoletoPayment();
                case "eletronictransfer":
                    return new EletronicTransferPayment();
                default:
                    return null;
            }
        }
    }
}