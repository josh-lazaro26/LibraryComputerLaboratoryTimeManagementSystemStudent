using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Models.StudentDao;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services.StudentServices
{
    public class StudentServices
    {
        private static HttpClient Client => ApiConfig.Client;

        public async Task<bool> AuthenticateByRfidAsync(string rfid)
        {
            string payload = $@"
            {{
                ""rfid"": ""{rfid}""
            }}";

            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/v1/auth/authenticate/rfid", content);

            var body = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
            System.Diagnostics.Debug.WriteLine($"Body: {body}");

            if (!response.IsSuccessStatusCode)
                return false;

            var json = JObject.Parse(body);

            // token
            var newToken = (string)json["value"]?["token"];

            if (!string.IsNullOrWhiteSpace(newToken))
                ApiConfig.Token = newToken;
            // student id
            var studentIdToken = json["value"]?["studentId"];
            if (studentIdToken != null && int.TryParse(studentIdToken.ToString(), out var sid))
                StudentDao.StudentId = sid;

            return true;
        }

        public async Task<string> GetStudentByIdAsync(int id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(ApiConfig.Token))
                {
                    Client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiConfig.Token);
                }
                var response = await Client.GetAsync($"api/v1/students/{id}");

                var body = await response.Content.ReadAsStringAsync();
                //System.Diagnostics.Debug.WriteLine(
                //    $"GET /api/v1/students/{id} => {(int)response.StatusCode} {response.StatusCode}");
                //System.Diagnostics.Debug.WriteLine(body);

                response.EnsureSuccessStatusCode();

                return body;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        // Convenience overload using the globally stored StudentDao id
        public Task<string> GetCurrentStudentAsync()
        {
            return GetStudentByIdAsync(StudentDao.StudentId);
        }
    }
}
