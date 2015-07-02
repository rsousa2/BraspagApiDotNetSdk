using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraspagApiDotNetSdk.Contracts
{
    public class ExternalAuthentication
    {
        public string Cavv { get; set; }
        public string Xid { get; set; }
        public string Eci { get; set; }
    }
}
