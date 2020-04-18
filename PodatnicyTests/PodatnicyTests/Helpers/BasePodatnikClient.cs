using System.Net;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharp.Authenticators;
using PodatnicyTests.AppSettings;
using NUnit.Framework;
namespace PodatnicyTests.Helpers
{
   public class BasePodatnikClient
    {
        public string BaseApiUrl { get; set; }


        public BasePodatnikClient()
        {
            this.BaseApiUrl = TestSettings.GetValue($"PartnerSettings:{TestSettings.HostingEnvironment}:Url");

        }

        public RestClient CreateRestClient(string expectedApi)
        {
            string restClientUrl = string.Empty;
            restClientUrl = TestSettings.GetValue($"PartnerSettings:{expectedApi}:Url");
            return new RestClient(restClientUrl);
        }

        public IRestResponse<T> GetResponse<T>(RestRequest request, HttpStatusCode httpStatusCode)
    where T : new()
        {
            var client = new RestClient(this.BaseApiUrl);
            client.RemoveHandler("application/json");
            if (client.Timeout < 22000)
            {
                client.Timeout = 22000;
            }

            client.AddHandler("application/json", () => new JsonDeserializer() { Culture = new System.Globalization.CultureInfo("pl-PL") });
            IRestResponse<T> response = client.Execute<T>(request);
            // Assert.AreEqual(httpStatusCode, response.StatusCode, $"Wrong HTTP status for response. Check response from API: {response.ToString()}");
            Assert.IsNull(response.ErrorException, $"Error retrieving response from {client.BuildUri(request).ToString()}. Check inner details for more info");

            return response;
        }


    }
}
