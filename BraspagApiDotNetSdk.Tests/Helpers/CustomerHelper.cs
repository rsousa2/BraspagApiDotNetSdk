using BraspagApiDotNetSdk.Contracts;
using System;

namespace BraspagApiDotNetSdk.Tests.Helpers
{
	public static class CustomerHelper
	{
		public static Customer CreateCustomer()
		{
			return new Customer
			{
				Address = new Address
				{
					City = "Rio de Janeiro",
					Complement = "Casa A",
					Country = "Brasil",
					District = "Centro",
					Number = "111",
					State = "RJ",
					Street = "Av Rio Branco",
					ZipCode = "99999999"
				},
				Birthdate = new DateTime(1990, 01, 01, 00, 00, 00),
				Email = "teste@teste.com",
				Identity = "99999999999",
				IdentityType = "CPF",
				Name = "Customer teste"
			};
		}
	}
}
