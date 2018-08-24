using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Edge.DataAccess.Cloud.ApiAccess
{

    public class CloudAccess<T> where T : class
    {
        private readonly string _baseAddress;

        public CloudAccess()
        {
            _baseAddress = ConfigurationManager.AppSettings["CloudAPIURL"].ToString();
        }

        private void SetupClient(HttpClient client, string methodName, string apiUrl, T content = null)
        {
            client.BaseAddress = new Uri(_baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetSingleString(string apiUrl)
        {
            string result = string.Empty;

            using (var client = new HttpClient())
            {
                SetupClient(client, "GET", apiUrl);

                var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = x.Result.ToString();
                });
            }

            return result;
        }

        public async Task<T> GetSingleItemRequest(string apiUrl)
        {
            T result = null;

            using (var client = new HttpClient())
            {
                SetupClient(client, "GET", apiUrl);

                var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<T>(x.Result);
                });
            }

            return result;
        }


        public async Task<T[]> GetMultipleItemsRequest(string apiUrl)
        {
            T[] result = null;

            using (var client = new HttpClient())
            {
                SetupClient(client, "GET", apiUrl);

                var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<T[]>(x.Result);
                });
            }

            return result;
        }


        //public async Task<T> PostRequest(string apiUrl, T postObject)
        //{
        //    T result = null;

        //    using (var client = new HttpClient())
        //    {
        //        SetupClient(client, "POST", apiUrl, postObject);

        //        var response = await client.PostAsync(apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);

        //        response.EnsureSuccessStatusCode();

        //        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        //        {
        //            if (x.IsFaulted)
        //                throw x.Exception;

        //            result = JsonConvert.DeserializeObject<T>(x.Result);

        //        });
        //    }

        //    return result;
        //}


        //public async Task PutRequest(string apiUrl, T putObject)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        SetupClient(client, "PUT", apiUrl, putObject);

        //        var response = await client.PutAsync(apiUrl, putObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);

        //        response.EnsureSuccessStatusCode();
        //    }
        //}


        public async Task DeleteRequest(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                SetupClient(client, "DELETE", apiUrl);

                var response = await client.DeleteAsync(apiUrl).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
            }
        }
    }

}
