using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace GuidMeWebApp.Models.Test
{
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            LanguagePerson lgPerson = new LanguagePerson()
            {
                CodeLanguage = "fra-fr",
                Name = "Français",

            };
            context.LanguagePersons.Add(lgPerson);
            context.SaveChanges();

            Place placed = new Place()
            {
                IdPlace = "namur0001",

                Address = "Rue des coqueliquos, 27 5000 Namur",

                Position = DbGeography.FromText("POINT(4.861107 50.459908)"),
            };
            context.Places.Add(placed);
            context.SaveChanges();

            TranslationPlace translationPlace = new TranslationPlace()
            {
                IdTranslationPlace = 1,
                TranslationNamePlace = "Citadelle",
                CodeLanguage = lgPerson,
                Place = placed,

            };

            context.TranslationPlaces.Add(translationPlace);

            context.SaveChanges();
        }
    }
}