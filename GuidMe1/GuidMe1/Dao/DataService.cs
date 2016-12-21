using GuidMe1.Error;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    class DataService
    {
        private HttpClient pc;
        private HttpClient pc2;
        private HttpClient pc3;
        private ApplicationError error;
        public static string Token { get; set; }
        public DataService()
        {
            pc = new HttpClient();
            pc2 = new HttpClient();
            pc3 = new HttpClient();
            error = new Error.ApplicationError();
        }

        public async Task<ApplicationError> GetToken(string _email, string _password)
        {
            var form = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", _email},
                {"password", _password},
            };
            try
            {
                var tokenResponse = pc.PostAsync(new Uri("http://localhost:57610/token"), new FormUrlEncodedContent(form)).Result;
                if (tokenResponse.IsSuccessStatusCode)
                {
                    error.IsOk = tokenResponse.IsSuccessStatusCode;
                    var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                    pc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
                    error.ErrorMessage = token.AccessToken; // recupère le token
                    Token = token.AccessToken;
                    var authorizedResponse = pc.GetAsync(new Uri("http://localhost:57610/api/Values")).Result;
                    return error;
                }
                else
                {
                    error.ErrorMessage = tokenResponse.Content.ReadAsStringAsync().Result;
                    error.IsOk = tokenResponse.IsSuccessStatusCode;
                    return error;
                }
            }
            catch(Exception e)
            {
                error.ErrorMessage = e.ToString();
                error.IsOk = false;
                return error;
            }
        }
        public async Task<Person> GetPerson()
        {
            pc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            var json = await pc.GetStringAsync(new Uri("http://localhost:57610/api/Account/Users"));
            Person returnedData = JsonConvert.DeserializeObject<Person>(json);
            return returnedData;
        }
        
        public async Task<IEnumerable<TranslationPlace>> GetPlace()
        {
            var json = await pc.GetStringAsync(new Uri("http://localhost:57610/api/TranslationPlaces"));
            TranslationPlace[] returnedPlace = JsonConvert.DeserializeObject<TranslationPlace[]>(json);
            return returnedPlace;
        }

        public async Task<Place> GetPlaceId(string id)
        {
            pc2.BaseAddress = new Uri("http://localhost:57610/api/Places/" + id);
            var json = await pc2.GetStringAsync(pc2.BaseAddress);
            Place returnedPlace = JsonConvert.DeserializeObject<Place>(json);
            return returnedPlace;
        }

        public async Task<ApplicationError> AddNewUser(RegisterBindingModel p)
        {
            pc.BaseAddress = new Uri("http://localhost:57610/api/Account/Register");
            try
            {
                var response = pc.PostAsJsonAsync(pc.BaseAddress, p).Result;
                if (response.IsSuccessStatusCode)
                {
                    error.ErrorMessage = response.Content.ReadAsStringAsync().Result;
                    error.IsOk = response.IsSuccessStatusCode;
                    return error;
                }
                else
                {
                    error.ErrorMessage = response.Content.ReadAsStringAsync().Result;
                    error.IsOk = response.IsSuccessStatusCode;
                    return error;
                }
            }
            catch(Exception e)
            {
                error.ErrorMessage = e.ToString();
                error.IsOk = false;
                return error;
            }
        }

        public async Task<ApplicationError> AddWantToGuide(Want_To_Guide wtg)
        {
            pc3.BaseAddress = new Uri("http://localhost:57610/api/Want_To_Guid");
            try
            {
                var response = pc3.PostAsJsonAsync(pc3.BaseAddress, wtg).Result;
                if (response.IsSuccessStatusCode)
                {
                    error.ErrorMessage = response.Content.ReadAsStringAsync().Result;
                    error.IsOk = response.IsSuccessStatusCode;
                    return error;
                }
                else
                {
                    error.ErrorMessage = response.Content.ReadAsStringAsync().Result;
                    error.IsOk = response.IsSuccessStatusCode;
                    return error;
                }
            }
            catch (Exception e)
            {
                error.ErrorMessage = e.ToString();
                error.IsOk = false;
                return error;
            }
        }

    }
}
