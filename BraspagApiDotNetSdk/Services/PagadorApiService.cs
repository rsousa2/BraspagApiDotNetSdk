using System.Collections.Generic;
using System.Net;
using BraspagApiDotNetSdk.Contracts;
using RestSharp;
using System;
using System.Configuration;
using RestSharp.Deserializers;

namespace BraspagApiDotNetSdk.Services
{
	public class PagadorApiService : IPagadorApiService
	{
		public IRestClient RestClient { get; set; }

		protected IDeserializer JsonDeserializer { get; set; }

		public PagadorApiService()
		{
			RestClient = new RestClient { BaseUrl = new Uri(ConfigurationManager.AppSettings["apiRootUrl"]) };
			JsonDeserializer = new JsonDeserializer();
		}

		public Sale CreateSale(MerchantAuthentication merchantAuthentication, Sale sale)
		{
			var restRequest = new RestRequest(@"sales", Method.POST) { RequestFormat = DataFormat.Json };
			AddHeaders(restRequest, merchantAuthentication);

			restRequest.AddBody(sale);

			var response = RestClient.Execute<Sale>(restRequest);

			var saleResponse = response.StatusCode == HttpStatusCode.OK
				? JsonDeserializer.Deserialize<Sale>(response)
				: new Sale { ErrorDataCollection = JsonDeserializer.Deserialize<List<Error>>(response) };

			saleResponse.HttpStatus = response.StatusCode;

			return saleResponse;
		}

		public CaptureResponse Capture(Guid paymentId, MerchantAuthentication merchantAuthentication, CaptureRequest captureRequest)
		{
			var restRequest = new RestRequest(@"sales/{paymentId}/capture", Method.PUT) { RequestFormat = DataFormat.Json };
			AddHeaders(restRequest, merchantAuthentication);

			restRequest.AddUrlSegment("paymentId", paymentId.ToString());

			if (captureRequest != null)
			{
				restRequest.AddQueryParameter("amount", captureRequest.Amount.ToString());
				restRequest.AddQueryParameter("serviceTaxAmount", captureRequest.ServiceTaxAmount.ToString());
			}

			var response = RestClient.Execute<CaptureResponse>(restRequest);

			var captureResponse = response.StatusCode == HttpStatusCode.OK
				? JsonDeserializer.Deserialize<CaptureResponse>(response)
				: new CaptureResponse { ErrorDataCollection = JsonDeserializer.Deserialize<List<Error>>(response) };

			captureResponse.HttpStatus = response.StatusCode;

			return captureResponse;
		}

		public VoidResponse Void(Guid paymentId, MerchantAuthentication merchantAuthentication, int? amount)
		{
			var restRequest = new RestRequest(@"sales/{paymentId}/void", Method.PUT) { RequestFormat = DataFormat.Json };
			AddHeaders(restRequest, merchantAuthentication);

			restRequest.AddUrlSegment("paymentId", paymentId.ToString());

			if (amount != null)
			{
				restRequest.AddQueryParameter("amount", amount.ToString());
			}

			var response = RestClient.Execute<VoidResponse>(restRequest);

			var voidResponse = response.StatusCode == HttpStatusCode.OK
				? JsonDeserializer.Deserialize<VoidResponse>(response)
				: new VoidResponse { ErrorDataCollection = JsonDeserializer.Deserialize<List<Error>>(response) };

			voidResponse.HttpStatus = response.StatusCode;

			return voidResponse;
		}

		public Sale Get(Guid paymentId, MerchantAuthentication merchantAuthentication)
		{
			var restRequest = new RestRequest(@"sales/{paymentId}", Method.GET) { RequestFormat = DataFormat.Json };
			AddHeaders(restRequest, merchantAuthentication);

			restRequest.AddUrlSegment("paymentId", paymentId.ToString());

			var response = RestClient.Execute<Sale>(restRequest);

			var saleResponse = response.StatusCode == HttpStatusCode.OK
				? JsonDeserializer.Deserialize<Sale>(response)
				: new Sale { ErrorDataCollection = JsonDeserializer.Deserialize<List<Error>>(response) };

			saleResponse.HttpStatus = response.StatusCode;

			return saleResponse;
		}

		private static void AddHeaders(IRestRequest request, MerchantAuthentication auth)
		{
			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("MerchantId", auth.MerchantId.ToString());
			request.AddHeader("MerchantKey", auth.MerchantKey);
		}
	}
}
