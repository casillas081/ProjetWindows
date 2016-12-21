using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    public class TranslationPlace
    {
        public int IdTraslationPlace { get; set; }

        public String TranslationNamePlace { get; set; }
        public virtual LanguagePerson CodeLanguage { get; set; }
        public virtual Place Place { get; set; }

        public TranslationPlace()
        {

        }

        public string GetIdPlace()
        {
            return Place.IdPlace;
        }
    }
}
