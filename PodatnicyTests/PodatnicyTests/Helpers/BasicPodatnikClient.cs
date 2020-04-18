using System.Net;
using System.Collections.Generic;
using PodatnicyTests.Models;
using RestSharp;


namespace PodatnicyTests.Helpers
{
    public class BasicPodatnikClient:BasePodatnikClient
    {
        public BasicPodatnikClient() : base()
        {
        }
            //public BankAccount GetBankAccountByNIP (string nip, string bankAccount, HttpStatusCode httpStatusCode= HttpStatusCode.OK)
            //{
            //    RestClient client = new RestClient();
            //    RestRequest request = new RestRequest($"api/check/nip/{nip}/bank-account/{bankAccount}", Method.GET);
            //    request.RequestFormat = DataFormat.Json;
            //    request.Timeout = 2000;

            //    return GetResponse<BankAccount>(request, httpStatusCode).Data;
            //}


        public ResponseContent GetBankAccountByNIP(string nip, string bankAccount, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"api/check/nip/{nip}/bank-account/{bankAccount}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Timeout = 2000;

            return GetResponse<ResponseContent>(request, httpStatusCode).Content.ToString();
        }



    }
}
