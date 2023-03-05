using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;
using System;
using System.Net.Http.Json;
using System.Text;

namespace HW_5_1_HTTP_StatusCodes
{
    public class Program
    {
        //HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            SendAsync().GetAwaiter().GetResult();
            Console.Read();
        }

        private async static Task SendAsync()
        {
            //GET List Users
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(@"https://reqres.in/api/users?page=2");
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }
            }

            //GET Single User
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(@"https://reqres.in/api/users/2");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }
            }

            //GET Single User Not Found
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(@"https://reqres.in/api/users/23");
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Error 404");
                }

            }

            //GET LIST < RESOURCE >
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(@"https://reqres.in/api/unknown");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }
            }

            //GET SINGLE <RESOURCE>
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(@"https://reqres.in/api/unknown/2");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }

            }

            //GET SINGLE <RESOURCE> NOT FOUND
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(@"https://reqres.in/api/unknown/23");
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Error 404");
                }

            }

            //POST Create
            using (HttpClient client = new HttpClient())
            {
                var user = new
                {
                    name = "morpheus",
                    job = "leader"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://reqres.in/api/users", httpContent);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //Update PUT
            using (HttpClient client = new HttpClient())
            {
                var user = new
                {
                    name = "morpheus",
                    job = "zion resident"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://reqres.in/api/users/2", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //Update Patch
            using (HttpClient client = new HttpClient()) 
            {
                var user = new
                {
                    name = "morpheus",
                    job = "zion resident"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var result = await client.PatchAsync("https://reqres.in/api/users/2", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //Delete
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(@"https://reqres.in/api/users/2");
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine("Error 204: No Content");
                }

            } 

            //REGISTER - SUCCESSFUL POST
            using(HttpClient client = new HttpClient())
            {
                var payload = new
                {
                    email = "eve.holt@reqres.in",
                    password = "pistol"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://reqres.in/api/users/2", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //REGISTER - UNSUCCESSFUL POST
            using (HttpClient client = new HttpClient())
            {
                var payload = new
                {
                    email = "sydney@fife"
                };
                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://reqres.in/api/register", httpContent);

                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //LOGIN - SUCCESSFUL POST
            using(HttpClient client = new HttpClient())
            {
                var payload = new
                {
                    email = "eve.holt@reqres.in",
                    password = "cityslicka"
                };
                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://reqres.in/api/login", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //LOGIN - UNSUCCESSFUL POST
            using (HttpClient client = new HttpClient())
            {
                var payload = new
                {
                    email = "peter@klaven"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://reqres.in/api/register", httpContent);

                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //DELAYED RESPONSE GET
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(@"https://reqres.in/api/users?delay=3");
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
            }
        }
    }
 }

