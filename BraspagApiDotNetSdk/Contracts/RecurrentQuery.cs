using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BraspagApiDotNetSdk.Contracts.Enum;

namespace BraspagApiDotNetSdk.Contracts
{
    public class RecurrentQuery : BaseResponse
    {
        public Customer Customer { get; set; }
        public RecurrentPaymentQueryModel RecurrentPayment { get; set; }
    }
}
