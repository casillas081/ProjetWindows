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
            var json = await pc.GetStringAsync(new Uri("http://localhost:65534/api/People"));
            Person[] returnedData = JsonConvert.DeserializeObject<Person[]>(json);
            return returnedData;
        }

        public void AddNewUser(Person p)
        {
            //try
            //{
            //    var pc = new HttpClient();
            //    var addUser = await pc.AddUserAsync(new Uri("URL de notre API"));
            //}
            //catch
            //{

            //}
            

        }

    }
}
