using System.Net;
using System.Collections.Generic;
using PodatnicyTests.Models;
using RestSharp;
using System;

namespace PodatnicyTests.Helpers
{
    public class BasicPodatnikClient:BasePodatnikClient
    {
        public BasicPodatnikClient() : base()
        {
        }
        public BankAccount GetBankAccountByNIP(string nip, string bankAccount, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"api/check/nip/{nip}/bank-account/{bankAccount}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Timeout = 2000;

            var response = GetResponse<BankAccount>(request, httpStatusCode);
            Timer.SetDateResponse(DateTime.Now);

            return response.Data;
        }

        public BankAccount GetBankAccountByRegon(string regon, string bankAccount, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"api/check/regon/{regon}/bank-account/{bankAccount}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Timeout = 2000;

            var response = GetResponse<BankAccount>(request, httpStatusCode);

            return response.Data;
        }


    }
}
