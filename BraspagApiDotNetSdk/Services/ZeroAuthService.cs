using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using BraspagApiDotNetSdk.Contracts;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace BraspagApiDotNetSdk.Services
{
    public class ZeroAuthService : IZeroAuthService
    {
        public IRestClient RestClient { get; set; }

        protected IDeserializer JsonDeserializer { get; set; }

        public ZeroAuthService() : this(ConfigurationManager.AppSettings["apiRootUrl"]) { }

        public ZeroAuthService(string url)
        {
            RestClient = new RestClient(new Uri(url));
            JsonDeserializer = new JsonDeserializer();
        }

        public VerifyCardResponse VerifyCard(MerchantAuthentication merchantAuthentication, Card card)
        {
            var restRequest = new RestRequest(@"ZeroAuth", Method.POST) { RequestFormat = DataFormat.Json };
            AddHeaders(restRequest, merchantAuthentication);

            restRequest.AddBody(card);
            
            var response = RestClient.Execute(restRequest);
            
            VerifyCardResponse verifyCardResponse = null;

            if (response.StatusCode == HttpStatusCode.Created)
                verifyCardResponse = JsonConvert.DeserializeObject<VerifyCardResponse>(response.Content);
            else if (response.StatusCode == HttpStatusCode.BadRequest)
                verifyCardResponse = new VerifyCardResponse { ErrorDataCollection = JsonDeserializer.Deserialize<List<Error>>(response) };
            else if (response.StatusCode == 0)
            {
                verifyCardResponse = HandleErrorException(response);
            }
            else
                verifyCardResponse = new VerifyCardResponse();

            verifyCardResponse.HttpStatus = response.StatusCode;

            return verifyCardResponse;
        }

        private static void AddHeaders(IRestRequest request, MerchantAuthentication auth)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("MerchantId", auth.MerchantId.ToString());
            request.AddHeader("MerchantKey", auth.MerchantKey);
        }

        private static VerifyCardResponse HandleErrorException(IRestResponse response)
        {
            return new VerifyCardResponse
            {
                ErrorDataCollection = new List<Error>
                {
                    new Error
                    {
                        Code = -1,
                        Message = string.Format("ErrorMessage: {0} | ErrorException: {1}", response.ErrorMessage, response.ErrorException)
                    }
                }
            };
        }
    }
}
