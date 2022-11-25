using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace SDETAPI_CSharp.Core
{
    //Builder
    public class RestCore
    {
        private RestClient _restClient { get; }

        private static RestCore _instance;

        public static RestCore GetInstance
        {
            get
            {
                _instance ??= new RestCore();
                return _instance;
            }
        }

        private RestCore()
        {
            _restClient = new RestClient();
        }

        public RestRequest CreateRequest(string methodType, TextWriter textWriter, string url = null)
        {
            methodType = methodType.ToUpper();
            RestRequest restRequest;
            switch (methodType)
            {
                case "GET":
                    restRequest = new RestRequest(url, Method.Get);
                    break;

                case "POST":
                    restRequest = new RestRequest(url, Method.Post);
                    break;

                case "PUT":
                    restRequest = new RestRequest(url, Method.Put);
                    break;

                case "DELETE":
                    restRequest = new RestRequest(url, Method.Delete);
                    break;

                default:
                    throw new NotImplementedException($"Rest Method not valid. Must specifiy correctly. Current value: [{methodType}]" +
                                                      $"Current valid types: Get, Post, Put and Delete");
            }

            textWriter.WriteLine($"Created Request: {restRequest}");

            return restRequest;
        }

        public RestRequest CreateRequestWithHeaders(string methodType, List<KeyValuePair<string, string>> headerList, TextWriter textWriter, string url = null)
        {
            var restRequest = this.CreateRequest(methodType, textWriter, url);
            restRequest.AddHeaders(headerList);
            textWriter.WriteLine($"Adding Headers: {string.Join(", ", headerList.Select(x => $"{x.Key}: {x.Value}")).ToList()}");

            return restRequest;
        }

        public void AddRequestBody(RestRequest restRequest, object body, TextWriter textWriter)
        {
            restRequest.AddJsonBody(body);
            textWriter.WriteLine(body.ToString());
        }

        public RestResponse ExecuteRequest(RestRequest restRequest, TextWriter textWriter)
        {
            var response = this._restClient.Execute(restRequest);
            textWriter.WriteLine(response.StatusDescription);
            textWriter.WriteLine(response.Content.ToString());
            return response;
        }

        public void AddQueryParameters(
            RestRequest restRequest,
            [NotNull] List<KeyValuePair<string, string>> queryParameters
        )
        {
            queryParameters.ForEach(qp => restRequest.AddQueryParameter(qp.Key, qp.Value));
        }

        public T DeserializeJsonResponse<T>(RestResponse restResponse)
            => JsonConvert.DeserializeObject<T>(restResponse.Content.ToString());
    }
}
