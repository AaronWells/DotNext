using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                var key = Console.ReadKey().KeyChar;
                Console.WriteLine(key);
                TokenResponse tokenResponse;
                switch (key)
                {
                    case '0':
                        tokenResponse = RetrieveTokenResponse("client", "secret").Result;
                        break;
                    case '1':
                        tokenResponse = RetrieveTokenResponse("client1", "secret").Result;
                        break;
                    case '2':
                        tokenResponse = RetrieveTokenResponse("client2", "secret").Result;
                        break;
                    case '3':
                        tokenResponse = RetrieveTokenResponse("client3", "secret").Result;
                        break;
                    default:
                        return;
                }
                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                }
                //Console.WriteLine(tokenResponse.Json);
                //GetClaimsData(tokenResponse);
                GetPeopleData(tokenResponse);
            } while (true);
        }

        public static async Task<TokenResponse> RetrieveTokenResponse(string key, string secret)
        {
            // discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            // request token
            var tokenClient = new TokenClient(disco.TokenEndpoint, key, secret);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
            return tokenResponse;
        }

        private static void GetPeopleData(TokenResponse tokenResponse)
        {
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("http://localhost:5001/api/people"),
                Method = HttpMethod.Get,
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.SendAsync(request).Result;

            //var response = client.GetAsync("http://localhost:5001/api/people").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }

            var content = response.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrEmpty(content))
            {
                Console.WriteLine("no content");
            }
            else
            {
                Console.WriteLine(JArray.Parse(content));
            }
        }

        public static void GetClaimsData(TokenResponse tokenResponse)
        {
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = client.GetAsync("http://localhost:5001/api/claims").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }

            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(JArray.Parse(content));
        }
    }
}
