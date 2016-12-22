using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    public class Want_To_Guid
    {
        public int IdWantToGuid { get; set; }
        public RegisterBindingModel Person { get; set; }
        public Place Place { get; set; }

        public Want_To_Guid(RegisterBindingModel p, Place pl)
        {
            Person = p;
            Place = pl;
        }
    }
}
