
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;

namespace NET_Challenge
{

    [TestFixture]
    public class ApiTest
    {
        RestClient restClient;
        private readonly string BaseUrl = "http://localhost:8080";


        [SetUp]
        public void SetUp()
        {
            restClient = new RestClient(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator("lafecaco", "bladimir55")
            };

        }
        [Test]
        public void TestNewEpicToAStory()
        {
            var request = new RestRequest("/rest/api/latest/issue/");
            string body = "{\"fields\": {\"project\":{\"key\": \"DEMO\"},\"summary\": \"My Epic created from the API\",\"description\": \"Creating of an Epic using project keys and issue type names using the REST API\",\"issuetype\": {\"name\": \"Epic\"},\r\n\"customfield_10104\": \"MyEpic\"}}";
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            var response = restClient.Post(request);
            Console.WriteLine(response.Content);
        }
        
      
    }
}
