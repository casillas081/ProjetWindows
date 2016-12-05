using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    public class Place
    {
        public String IdPlace { get; set; }
        public String NamePlace { get; set; }
        public String Adresse { get; set; }
        public Double CoordLat { get; set; }
        public Double CoordLong { get; set; }

        public Place()
        {

        }
    }
}
