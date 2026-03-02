using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Models.StudentDao;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services.StudentServices
{
    public class StudentServices
    {
        private static HttpClient Client => ApiConfig.Client;

        public async Task<bool> AuthenticateByRfidAsync(string rfid)
        {
            string payload = $@"{{ ""rfid"": ""{rfid}"" }}";
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/v1/accounts/authenticate", content);
            var body = await response.Content.ReadAsStringAsync();

            System.Diagnostics.Debug.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
            System.Diagnostics.Debug.WriteLine($"Body ni kristo: {body}");


            if (!response.IsSuccessStatusCode)
                return false;

            var json = JObject.Parse(body);
            var newToken = (string)json["access_token"];
            var durationStr = (string)json["duration"];

            if (!string.IsNullOrWhiteSpace(newToken))
            {
                ApiConfig.Token = newToken;

                // Decode JWT payload
                var parts = newToken.Split('.');
                if (parts.Length == 3)
                {
                    var payloadBase64 = parts[1];
                    payloadBase64 = payloadBase64.PadRight(payloadBase64.Length + (4 - payloadBase64.Length % 4) % 4, '=');
                    var payloadJson = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(payloadBase64));
                    var jwtPayload = JObject.Parse(payloadJson);
                    StudentDao.SchoolId = jwtPayload["school_id"]?.ToString();
                    Console.WriteLine("jaydabolyutee peylod: " + jwtPayload);
                }
            }

            StudentDao.Duration = durationStr;

            Console.WriteLine($"Token: {ApiConfig.Token}");
            Console.WriteLine($"Duration: {StudentDao.Duration}");
            Console.WriteLine($"School ID: {StudentDao.SchoolId}");
            return true;
        }

        public async Task<bool> Logout()
        {
            try
            {
                Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", ApiConfig.Token);

                var response = await Client.PostAsync("api/v1/accounts/logout", null);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Logout failed: {response.StatusCode}");
                    return false;
                }

                // Clear token after successful logout
                ApiConfig.Token = null;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during logout: {ex.Message}");
                return false;
            }
        }
    }
}