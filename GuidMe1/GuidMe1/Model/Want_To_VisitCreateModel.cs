using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    public class Want_To_VisitCreateModel
    {
        public string Id { get; set; }
        public String Address { get; set; }
        public string IdPlace { get; set; }

        public Want_To_VisitCreateModel(string id, String adr, string idPlace)
        {
            this.Id = id;
            this.Address = adr;
            this.IdPlace = idPlace;
        }
    }
}