using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

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

        public RestRequest CreateRequest(string methodType, string url = null)
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

            return restRequest;
        }

        public RestRequest CreateRequestWithHeaders(string methodType, List<KeyValuePair<string, string>> headerList, string url = null)
        {
            var restRequest = this.CreateRequest(methodType, url);
            restRequest.AddHeaders(headerList);

            return restRequest;
        }

        public void AddRequestBody(RestRequest restRequest, object body)
        {
            restRequest.AddJsonBody(body);
            Console.WriteLine(body.ToString());
        }

        public RestResponse ExecuteRequest(RestRequest restRequest)
        {
            var response = this._restClient.Execute(restRequest);
            Console.WriteLine(response.StatusDescription);
            Console.WriteLine(response.Content.ToString());
            return response;
        }

        public void AddQueryParameters(RestRequest restRequest, [NotNull] List<KeyValuePair<string, string>> queryParameters)
        {
            queryParameters.ForEach(qp => restRequest.AddQueryParameter(qp.Key, qp.Value));
        }
    }
}
