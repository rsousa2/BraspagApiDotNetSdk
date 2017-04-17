using System;
using System.Linq;
using System.Net;
using BraspagApiDotNetSdk.Contracts;
using BraspagApiDotNetSdk.Services;
using BraspagApiDotNetSdk.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using RestSharp.Serializers;

namespace BraspagApiDotNetSdk.Tests
{
    [TestClass]
    public class ZeroAuthTests
    {
        private Mock<IRestClient> _mockRestClient;

        private IZeroAuthService _zeroAuthService;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRestClient = new Mock<IRestClient>();

            _zeroAuthService = new ZeroAuthService
            {
                RestClient = _mockRestClient.Object
            };
        }

        [TestMethod]
        public void VerifyCard_WhenVerifyIsSuccessAndCardIsOk_ShouldFillResponseCorrectly()
        {
            var cardRequest = ZeroAuthHelper.ValidCardRequest();
            
            _mockRestClient.Setup(m => m.Execute(It.IsAny<IRestRequest>())).Returns(new RestResponse<string>
            {
                StatusCode = HttpStatusCode.Created,
                Content = ZeroAuthHelper.ValidZeroAuthResponseWithTrueResponse(),
                Data = ZeroAuthHelper.ValidZeroAuthResponseWithTrueResponse()
            });

            var response = _zeroAuthService.VerifyCard(new MerchantAuthentication(),  cardRequest);

            _mockRestClient.Verify(m => m.Execute(It.IsAny<RestRequest>()), Times.Once);

            _mockRestClient.Verify(m => m.Execute(It.Is<RestRequest>(request => request.Method == Method.POST)), Times.Once);
            
            _mockRestClient.Verify(m => m.Execute(It.Is<RestRequest>(request => request.Parameters.Any(
                param => param.Type == ParameterType.RequestBody && param.Name == @"application/json"))), Times.Once);

            response.Should().NotBeNull();
            response.ErrorDataCollection.Should().BeNull();
            response.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void VerifyCard_WhenVerifyIsSuccessAndCardIsKo_ShouldFillResponseCorrectly()
        {
            var cardRequest = ZeroAuthHelper.ValidCardRequest();

            _mockRestClient.Setup(m => m.Execute(It.IsAny<IRestRequest>())).Returns(new RestResponse<string>
            {
                StatusCode = HttpStatusCode.Created,
                Content = ZeroAuthHelper.ValidZeroAuthResponseWithFalseResponse(),
                Data = ZeroAuthHelper.ValidZeroAuthResponseWithFalseResponse()
            });

            var response = _zeroAuthService.VerifyCard(new MerchantAuthentication(), cardRequest);

            _mockRestClient.Verify(m => m.Execute(It.IsAny<RestRequest>()), Times.Once);

            _mockRestClient.Verify(m => m.Execute(It.Is<RestRequest>(request => request.Method == Method.POST)), Times.Once);

            _mockRestClient.Verify(m => m.Execute(It.Is<RestRequest>(request => request.Parameters.Any(
                param => param.Type == ParameterType.RequestBody && param.Name == @"application/json"))), Times.Once);

            response.Should().NotBeNull();
            response.ErrorDataCollection.Should().BeNull();
            response.IsValid.Should().BeFalse();
        }
        
        [TestMethod]
        public void VerifyCard_WhenVerifyIsFailedAndHasOneError_ShouldFillResponseCorrectly()
        {
            var cardRequest = ZeroAuthHelper.ValidCardRequest();

            _mockRestClient.Setup(m => m.Execute(It.IsAny<IRestRequest>())).Returns(new RestResponse<string>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = ZeroAuthHelper.InvalidZeroAuthResponseOneError(),
                Data = ZeroAuthHelper.InvalidZeroAuthResponseOneError()
            });

            var response = _zeroAuthService.VerifyCard(new MerchantAuthentication(), cardRequest);

            response.Should().NotBeNull();
            response.ErrorDataCollection.Should().NotBeNull();
            response.ErrorDataCollection.Should().HaveCount(1);
            response.ErrorDataCollection.Should().ContainSingle(o => o.Code == 322 && o.Message == "Zero Dollar Auth is not enabled");
        }

        [TestMethod]
        public void VerifyCard_WhenVerifyIsFailedAndHasTwoError_ShouldFillResponseCorrectly()
        {
            var cardRequest = ZeroAuthHelper.ValidCardRequest();

            _mockRestClient.Setup(m => m.Execute(It.IsAny<IRestRequest>())).Returns(new RestResponse<string>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = ZeroAuthHelper.InvalidZeroAuthResponseTwoErrors(),
                Data = ZeroAuthHelper.InvalidZeroAuthResponseTwoErrors()
            });

            var response = _zeroAuthService.VerifyCard(new MerchantAuthentication(), cardRequest);

            response.Should().NotBeNull();
            response.ErrorDataCollection.Should().NotBeNull();
            response.ErrorDataCollection.Should().HaveCount(2);
            response.ErrorDataCollection.Should().ContainSingle(o => o.Code == 322 && o.Message == "Zero Dollar Auth is not enabled");
            response.ErrorDataCollection.Should().ContainSingle(o => o.Code == 1 && o.Message == "Unexpected end of file");
        }


        [TestMethod]
        public void VerifyCard_WhenHttpStatusCodeEqualsTo0_ReturnsMappedErrorResponse()
        {
            var restResponse = new RestResponse
            {
                StatusCode = 0,
                ErrorException = new Exception("Test exception"),
                ErrorMessage = "Undefined Error"
            };

            _mockRestClient.Setup(m => m.Execute(It.IsAny<IRestRequest>())).Returns(restResponse);

            var response = _zeroAuthService.VerifyCard(MerchantAuthenticationHelper.CreateMerchantAuthentication(), ZeroAuthHelper.ValidCardRequest());

            response.Should().NotBeNull();
            Assert.AreEqual(response.HttpStatus, restResponse.StatusCode);
            response.ErrorDataCollection.Should().NotBeNull();
            response.ErrorDataCollection[0].Code.Should().Be(-1);
            response.ErrorDataCollection[0].Message.Should().Be("ErrorMessage: Undefined Error | ErrorException: System.Exception: Test exception");
        }
    }
}
