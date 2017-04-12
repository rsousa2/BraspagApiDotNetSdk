using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BraspagApiDotNetSdk.Contracts;

namespace BraspagApiDotNetSdk.Services
{
    public interface IZeroAuthService
    {
        VerifyCardResponse VerifyCard(MerchantAuthentication merchantAuthentication, Card card);
    }
}
