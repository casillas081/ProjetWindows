using GuidMe1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Dao
{
    class GuideService
    {
        private HttpClient pc;

        public GuideService()
        {
            pc = new HttpClient();
        }
        public async Task<IEnumerable<Want_To_Guid>> GetWantDoVisit()
        {
            pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenGlobal.Token);
            var json = await pc.GetStringAsync(new Uri("http://localhost:57610/api/Want_To_Guid"));
            Want_To_Guid[] returnedData = JsonConvert.DeserializeObject<Want_To_Guid[]>(json);
            return returnedData;
        }
    }
}
