using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    public static class AllPersons
    {
        public static IEnumerable<Person> Persons { get; set; }
        public static IEnumerable<Person> GetAllPersons()
        {
            return new List<Person>
            {
                new Person("Garaith","MotdePasse1", "Julien", "Demoustier", true, "Belge"),
                new Person("KaZzy", "MotdePasse2","Loic", "Cheron", true, "Belge"),
                new Person("Caelus", "MotdePasse2", "Christophe", "Schepmans", true, "Belge"),
                new Person("Samiroquai", "MotdePasse2", "Samuel", "Choltes", true, "Belge"),
                new Person("Pikapichu", "MotdePasse2","Christine", "Charlier", false,  "Belge"),
                new Person("Kediss", "MotdePasse2","Valentin", "Veny", true,  "Belge")
            };
        }
    }
}
