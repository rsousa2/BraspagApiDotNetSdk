using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BraspagApiDotNetSdk.Contracts;

namespace BraspagApiDotNetSdk.Tests.Helpers
{
    public static class VoidTransactionHelper
    {
        public static VoidRequest CreateValidVoidRequest()
        {
            return new VoidRequest
            {
                Amount = 15057
            };
        }
    }
}
