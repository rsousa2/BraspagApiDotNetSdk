using System;
using System.Net;
using BraspagApiDotNetSdk.Contracts;

namespace BraspagApiDotNetSdk.Services
{
    public interface IPagadorRecurrentApiService
    {
        HttpStatusCode UpdateCustomerData(Guid recurrentId, MerchantAuthentication merchantAuthentication,Customer customer);

        HttpStatusCode UpdateRecurrentPaymentEndDate(Guid recurrentId, MerchantAuthentication merchantAuthentication,DateTime endDate);

        HttpStatusCode UpdateRecurrentPaymentInterval(Guid recurrentId, MerchantAuthentication merchantAuthentication,int interval);

        HttpStatusCode UpdateRecurrentPaymentRecurrencyDay(Guid recurrentId,MerchantAuthentication merchantAuthentication, byte day);

        HttpStatusCode ReactivateRecurrentPayment(Guid recurrentId, MerchantAuthentication merchantAuthentication);

        HttpStatusCode DeactivateRecurrentPayment(Guid recurrentId, MerchantAuthentication merchantAuthentication);

        HttpStatusCode UpdateRecurrentPaymentInstallments(Guid recurrentId,MerchantAuthentication merchantAuthentication, byte installments);

        HttpStatusCode UpdateRecurrentPaymentNextPaymentDate(Guid recurrentId,MerchantAuthentication merchantAuthentication, DateTime nextPaymentDate);

        HttpStatusCode UpdateRecurrentPayment(Guid recurrentId, MerchantAuthentication merchantAuthentication,Payment updatedPayment);

        HttpStatusCode UpdateRecurrentAmount(Guid recurrentId, MerchantAuthentication merchantAuthentication,long amount);

        HttpStatusCode UpdateRecurrentAffiliation(Guid recurrentId, MerchantAuthentication merchantAuthentication,PaymentCredentials affiliation);

        RecurrentQuery Get(Guid recurrentId, MerchantAuthentication merchantAuthentication);
    }
}
