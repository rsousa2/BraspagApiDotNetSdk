using BraspagApiDotNetSdk.Contracts;
using System;

namespace BraspagApiDotNetSdk.Tests.Helpers
{
    public static class SaleHelper
    {
        public static Sale CreateOrder(Payment payment)
        {
            return new Sale
            {
                MerchantOrderId = Guid.NewGuid().ToString(),
                Customer = CustomerHelper.CreateCustomer(),
				Payment = payment
            };
        }
    }
}
