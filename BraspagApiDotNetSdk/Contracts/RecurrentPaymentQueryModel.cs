using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BraspagApiDotNetSdk.Contracts.Enum;

namespace BraspagApiDotNetSdk.Contracts
{
    public class RecurrentPaymentQueryModel : BaseResponse
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

        public long Amount { get; set; }
        public string Country { get; set; }
        public DateTime CreateDate { get; set; }
        public string Currency { get; set; }
        public short CurrentRecurrencyTry { get; set; }
        public DateTime? NextRetry { get; set; }
        public string OrderNumber { get; set; }
        public ProviderEnum Provider { get; set; }
        public byte RecurrencyDay { get; set; }
        public short SuccessfulRecurrences { get; set; }

        public List<Link> Links { get; set; }

        public List<RecurrentTransaction> RecurrentTransactions { get; set; }

        public byte Status { get; set; }
    }
}
