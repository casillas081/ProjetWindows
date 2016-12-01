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
                new Person("Garaith", "Julien", "Demoustier", true, "MotdePasse1","Belge", true, 5),
                new Person("KaZzy", "Loic", "Cheron", true, "MotdePasse2","Belge", true, 4),
                new Person("Caelus", "Christophe", "Schepmans", true, "MotdePasse2","Belge", true, 3),
                new Person("Samiroquai", "Samuel", "Choltes", true, "MotdePasse2","Belge", true, 2),
                new Person("Pikapichu", "Christine", "Charlier", false, "MotdePasse2", "Belge", true,1),
                new Person("Kediss", "Valentin", "Veny", true, "MotdePasse2", "Belge", true, 0)
            };
        }
    }
}
