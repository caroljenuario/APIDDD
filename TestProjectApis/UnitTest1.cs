using Entitities.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace TestProjectApis
{
    [TestClass]
    public class UnitTest1
    {
        public static string Token { get; set; }
        [TestMethod]
        public void TestMethod1()
        {
            var result = CallPostApi("https://localhost:7197/api/List").Result;

            var listMessage = JsonConvert.DeserializeObject<Message[]>(result).ToList();

            Assert.IsTrue(listMessage.Any());
        }

        public void GetToken()
        {

            string urlApiGeraToken = "https://localhost:7197/api/CreateTokenIdentity";

            using (var client = new HttpClient())
            {
                string login = "carol@carol.com";
                string password = "@CarolNetCore123";
                var data = new
                {
                    email = login,
                    senha = password,
                    cpf = "string"
                };
                string JsonObjeto = JsonConvert.SerializeObject(data);
                var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");

                var result = client.PostAsync(urlApiGeraToken, content);
                result.Wait();
                if (result.Result.IsSuccessStatusCode)
                {
                    var tokenJson = result.Result.Content.ReadAsStringAsync();
                    Token = JsonConvert.DeserializeObject(tokenJson.Result).ToString();
                }

            }
        }

        public string CallGetApi(string url)
        {
            GetToken(); // Gerar token
            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = client.GetStringAsync(url);
                    response.Wait();
                    return response.Result;
                }
            }

            return null;
        }

        public async Task<string> CallPostApi(string url, object data = null)
        {

            string JsonObjeto = data != null ? JsonConvert.SerializeObject(data) : "";
            var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");

            GetToken(); // Gerar token
            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = client.PostAsync(url, content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var ret = await response.Result.Content.ReadAsStringAsync();

                        return ret;
                    }
                }
            }

            return null;

        }

    }
}