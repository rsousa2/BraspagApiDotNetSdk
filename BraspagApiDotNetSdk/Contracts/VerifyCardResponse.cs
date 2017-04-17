using System.Collections.Generic;
using Newtonsoft.Json;

namespace BraspagApiDotNetSdk.Contracts
{
    public class VerifyCardResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Valid")]
        public bool IsValid { get; set; }
    }
}
