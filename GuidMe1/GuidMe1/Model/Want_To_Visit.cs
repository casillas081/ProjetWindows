using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    public class Want_To_Visit
    {
        public int IdWantToGuid { get; set; }
        public Person Person { get; set; }
        public virtual Place Place { get; set; }
    }
}
