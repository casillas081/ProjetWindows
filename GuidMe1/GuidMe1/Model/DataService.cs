using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    class DataService
    {
        private HttpClient pc;
        public DataService()
        {
            pc = new HttpClient();
        }

        public async Task<IEnumerable<Person>> GetPerson()
        {
            var json = await pc.GetStringAsync(new Uri("http://guidme.azurewebsites.net/api/People"));
            Person[] returnedData = JsonConvert.DeserializeObject<Person[]>(json);
            return returnedData;
        }
        
        public async Task<IEnumerable<TranslationPlace>> GetPlace()
        {
            var json = await pc.GetStringAsync(new Uri("http://localhost:62552/api/TranslationPlaces"));
            var returnedPlace = JsonConvert.DeserializeObject<TranslationPlace[]>(json);
            return returnedPlace;
        }

        public async void AddNewUser(Person p)
        {
            try
            {
                await pc.PostAsJsonAsync(new Uri("http://localhost:62552/api/People"),p);               
            }
            catch
            {

            }


        }

    }
}
