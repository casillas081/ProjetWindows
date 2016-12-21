using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    public class Want_To_GuidCreateModel
    {
        public string Id { get; set; }
        public String Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Want_To_GuidCreateModel(string id, String adr, double lat, double longitude)
        {
            this.Id = id;
            this.Address = adr;
            this.Latitude = lat;
            this.Longitude = longitude;
        }
    }
}
