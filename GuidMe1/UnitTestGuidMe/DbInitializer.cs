using GuidMeClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestGuidMe
{
    public class DbInitializer : DropCreateDatabaseAlways<GuidMeContext>
    {
        protected override void Seed(GuidMeContext context)
        {
            LanguagePerson lgPerson = new LanguagePerson()
            {
                CodeLanguage = "fra-fr",
                Name = "Français",

            };

            Place placed = new Place()
            {
                IdPlace = "namur0001",

                Adresse = "Rue des coqueliquos, 27 5000 Namur",

                Position = DbGeography.FromText("POINT(4.861107 50.459908)"),
            };

            TranslationPlace translationPlace = new TranslationPlace()
            {
                IdTraslationPlace = 1,
                TranslationNamePlace = "Citadelle",
                IdLanguage = "fra",
                CodeLanguage = lgPerson,
                IdPlace = placed.IdPlace,
                Places = placed,

            };

            context.TranslationPlaces.Add(translationPlace);

            context.SaveChanges();

        }
    }
   
}
