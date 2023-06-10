using Newtonsoft.Json;
using RestSharp;
using WebApp.Configurations;
using WebApp.Models;

namespace WebApp.Utilities
{
    public static class RequestUtil
    {
        private static readonly RestClient _client = new RestClient(Configuration.ApiUrl);


        public static string GetToken()
        {
            return _client.Post(new RestRequest(Endpoints.GetToken).AddParameter("variant", ApiConfig.Variant)).Content;
        }

        public static string CreateTest(string sid, string projectName, string testName, string methodName, string env)
        {
            var response = _client.Post(new RestRequest(Endpoints.Put)
                .AddParameter("SID", sid)
                .AddParameter("projectName", projectName)
                .AddParameter("testName", testName)
                .AddParameter("methodName", methodName)
                .AddParameter("env", env));

            return response.Content;
        }
        public static void SendLogs(string testId, string logs)
        {
            _client.Post(new RestRequest(Endpoints.PutLog)
                .AddParameter("testId", testId)
                .AddParameter("content", logs));
        }

        public static void SendAttachment(string testId, string content, string type)
        {
            _client.Post(new RestRequest(Endpoints.PutAttachment)
              .AddParameter("testId", testId)
              .AddParameter("content", content)
              .AddParameter("contentType", type));
        }

        private static string GetTests(string projectId)
        {
            return _client.Post(new RestRequest(Endpoints.GetJson).AddParameter("projectId", projectId)).Content;
        }

        public static List<ProjectTests> GetTestsByJson(string projectId)
        {
            string json = "";
            while (true)
            {
                json = GetTests(projectId);
                if (ValidateClass.IsValidJson(json)) break;
            }
            return JsonConvert.DeserializeObject<List<ProjectTests>>(json);
        }
    }
}
