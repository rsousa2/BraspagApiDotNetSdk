using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using BraspagApiDotNetSdk.Contracts;
using RestSharp;
using RestSharp.Deserializers;

namespace BraspagApiDotNetSdk.Services
{
    public class PagadorRecurrentApiService : IPagadorRecurrentApiService
    {
        public IRestClient RestClient { get; set; }

        protected IDeserializer JsonDeserializer { get; set; }

        public PagadorRecurrentApiService() : this(ConfigurationManager.AppSettings["apiRootUrl"]){}

        public PagadorRecurrentApiService(string url)
        {
            RestClient = new RestClient { BaseUrl = new Uri(url) };
            JsonDeserializer = new JsonDeserializer();
        }

        public HttpStatusCode UpdateCustomerData(Guid recurrentId, MerchantAuthentication merchantAuthentication,Customer customer)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/Customer", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            restRequest.AddBody(customer);

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode UpdateRecurrentPaymentEndDate(Guid recurrentId,MerchantAuthentication merchantAuthentication, DateTime endDate)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/EndDate", Method.PUT){ RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            restRequest.AddBody(endDate);

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode UpdateRecurrentPaymentInterval(Guid recurrentId,MerchantAuthentication merchantAuthentication, int interval)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/Interval", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            restRequest.AddBody(interval);

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode UpdateRecurrentPaymentRecurrencyDay(Guid recurrentId, MerchantAuthentication merchantAuthentication, byte day)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/RecurrencyDay", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            restRequest.AddBody(day);

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode ReactivateRecurrentPayment(Guid recurrentId, MerchantAuthentication merchantAuthentication)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/Reactivate", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode DeactivateRecurrentPayment(Guid recurrentId, MerchantAuthentication merchantAuthentication)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/Deactivate", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode UpdateRecurrentPaymentInstallments(Guid recurrentId, MerchantAuthentication merchantAuthentication, byte installments)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/Installments", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            restRequest.AddBody(installments);

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode UpdateRecurrentPaymentNextPaymentDate(Guid recurrentId, MerchantAuthentication merchantAuthentication, DateTime nextPaymentDate)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/NextPaymentDate", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            restRequest.AddBody(nextPaymentDate);

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode UpdateRecurrentPayment(Guid recurrentId, MerchantAuthentication merchantAuthentication, Payment updatedPayment)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/Payment", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            restRequest.AddBody(updatedPayment);

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode UpdateRecurrentAmount(Guid recurrentId, MerchantAuthentication merchantAuthentication, long amount)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/Amount", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            restRequest.AddBody(amount);

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public HttpStatusCode UpdateRecurrentAffiliation(Guid recurrentId, MerchantAuthentication merchantAuthentication, PaymentCredentials affiliation)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}/Affiliation", Method.PUT) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            restRequest.AddBody(affiliation);

            var response = RestClient.Execute<HttpStatusCode>(restRequest);

            return response.StatusCode;
        }

        public RecurrentQuery Get(Guid recurrentId, MerchantAuthentication merchantAuthentication)
        {
            var restRequest = new RestRequest(@"RecurrentPayment/{recurrentId}", Method.GET) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddUrlSegment("recurrentId", recurrentId.ToString());

            var response = RestClient.Execute<RecurrentQuery>(restRequest);

            var recurrentResponse = response.StatusCode == HttpStatusCode.OK
                ? JsonDeserializer.Deserialize<RecurrentQuery>(response)
                : new RecurrentQuery { ErrorDataCollection = JsonDeserializer.Deserialize<List<Error>>(response) };

            recurrentResponse.HttpStatus = response.StatusCode;

            return recurrentResponse;
        }

        private static void AddHeaders(IRestRequest request, MerchantAuthentication auth)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("MerchantId", auth.MerchantId.ToString());
            request.AddHeader("MerchantKey", auth.MerchantKey);
        }
    }
}
