using System;
using BraspagApiDotNetSdk.Contracts.Enum;

namespace BraspagApiDotNetSdk.Contracts
{
    public class RecurrentPayment : BaseResponse
    {
        public Guid? RecurrentPaymentId { get; set; }

        public int ReasonCode { get; set; }

        public string ReasonMessage { get; set; }

        public DateTime? NextRecurrency { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public RecurrencyIntervalEnum Interval { get; set; }

        public Link Link { get; set; }

        public bool? AuthorizeNow { get; set; }

    }
}
