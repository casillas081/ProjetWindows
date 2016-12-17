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
        private ApplicationError error;
        public static string Token { get; set; }
        public DataService()
        {
            pc = new HttpClient();
            error = new Error.ApplicationError();
        }

        public async Task<ApplicationError> GetToken(string _pseudo, string _password)
        {
            var form = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", _pseudo},
                {"password", _password},
            };
            try
            {
                var tokenResponse = pc.PostAsJsonAsync(new Uri("http://guidme.azurewebsites.net/token"), new FormUrlEncodedContent(form)).Result;
                if (tokenResponse.IsSuccessStatusCode)
                {
                    error.IsOk = tokenResponse.IsSuccessStatusCode;
                    var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                    pc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
                    error.ErrorMessage = token.AccessToken; // recupère le token
                    Token = token.AccessToken;
                    var authorizedResponse = pc.GetAsync(new Uri("http://guidme.azurewebsites.net/api/Values")).Result;
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
            var json = await pc.GetStringAsync(new Uri("http://guidme.azurewebsites.net/api/Account/Users"));
            Person returnedData = JsonConvert.DeserializeObject<Person>(json);
            return returnedData;
        }
        
        public async Task<IEnumerable<TranslationPlace>> GetPlace()
        {
            var json = await pc.GetStringAsync(new Uri("http://localhost:62552/api/TranslationPlaces"));
            var returnedPlace = JsonConvert.DeserializeObject<TranslationPlace[]>(json);
            return returnedPlace;
        }

        public async Task<ApplicationError> AddNewUser(Person p)
        {
            pc.BaseAddress = new Uri("http://guidme.azurewebsites.net/api/Account/Register");
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

    }
}
