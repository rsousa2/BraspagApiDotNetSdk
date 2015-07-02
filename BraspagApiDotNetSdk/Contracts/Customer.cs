using System;

namespace BraspagApiDotNetSdk.Contracts
{
	public class Customer
	{
		public string Name { get; set; }

		public string Identity { get; set; }

		public string IdentityType { get; set; }

		public string Email { get; set; }

		public DateTime? Birthdate { get; set; }

		public Address Address { get; set; }

        public Address DeliveryAddress { get; set; }
	}
}
