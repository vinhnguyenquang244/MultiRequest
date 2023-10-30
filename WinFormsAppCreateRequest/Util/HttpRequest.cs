using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppCreateRequest.Util
{
    public class HttpRequest
    {
        public static  readonly string[] InvalidHeader = new string[] { "Accept-Encoding", "Connection", "Host", "unixtimestamp", "devicetype", "authorization", "retailer", "devicename", "securehash", "deviceos", "accept-language", "app", "deviceid", "user-agent" };
        public static async Task<string> PostRequest(string url, Dictionary<string, string> dataHeader, string requestBody)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Define the request URL
                    //string url = "https://example.com/api/resource";

                    // Create a new StringContent object with the request body
                    //string requestBody = "{\"name\": \"John\", \"age\": 30}";
                    var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
                    foreach (var header in dataHeader)
                    {
                        if (header.Key == "authorization" || header.Key == "Authorization")
                        {
                            client.DefaultRequestHeaders.Add("Authorization", header.Value);
                            continue;
                        }
                        if (InvalidHeader.Contains(header.Key))
                        {
                            client.DefaultRequestHeaders.Add(header.Key, Uri.EscapeDataString(header.Value));
                        }
                    }

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    string responseContent = string.Empty;
                    // Check the response status
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                        {
                            using (Stream stream = await response.Content.ReadAsStreamAsync())
                            using (GZipStream decompressionStream = new GZipStream(stream, CompressionMode.Decompress))
                            using (StreamReader reader = new StreamReader(decompressionStream))
                            {
                                responseContent = await reader.ReadToEndAsync();
                            }
                        }
                        else
                        {
                            // Request succeeded, process the response
                            responseContent = await response.Content.ReadAsStringAsync();
                        }
                        return responseContent;

                    }
                    else
                    {
                        // Request failed, print the status code
                        Console.WriteLine("Request failed with status code: " + response.StatusCode);
                        return "Request failed with status code: " + response.StatusCode;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
