using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraspagApiDotNetSdk.Contracts.Enum
{
    public enum ShippingMethodEnum
    {
        Undefined = 0,
        SameDay = 1,
        OneDay = 2,
        TwoDay = 3,
        ThreeDay = 4,
        LowCost = 5,
        Pickup = 6,
        Other = 7,
        None = 8,
    }
}
