using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BraspagApiDotNetSdk.Contracts;
using BraspagApiDotNetSdk.Contracts.Enum;

namespace BraspagApiDotNetSdk.Tests.Helpers
{
    public class ZeroAuthHelper
    {
        public static Card ValidCardRequest()
        {
            return new Card
            {
                CardNumber = "4532644096319193",
                Brand = BrandEnum.Visa,
                ExpirationDate = "12/2024",
                Holder = "AUDREY ALBERTSON",
                SecurityCode = "659"
            };
        }

        public static string ValidZeroAuthResponseWithTrueResponse()
        {
            return "{ \"Valid\": true }";
        }

        public static string ValidZeroAuthResponseWithFalseResponse()
        {
            return "{ \"Valid\": false }";
        }

        public static string InvalidZeroAuthResponseOneError()
        {
            return "[ { \"Code\": 322, \"Message\": \"Zero Dollar Auth is not enabled\" } ]";
        }
        public static string InvalidZeroAuthResponseTwoErrors()
        {
            return "[ { \"Code\": 322, \"Message\": \"Zero Dollar Auth is not enabled\" }, { \"Code\": 1, \"Message\": \"Unexpected end of file\" } ]";
        }
    }
}
