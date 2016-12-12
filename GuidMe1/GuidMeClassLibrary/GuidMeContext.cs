using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class GuidMeContext : DbContext
    {
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<LanguagePerson> LanguagePersons { get; set; }
        public DbSet<MatchVisitorGuide> MatchVisitorGuide { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Speak> Speaks { get; set; }
        public DbSet<Translation_Nationality> Translation_Nationalities { get; set; }
        public DbSet<TranslationPlace> TranslationPlaces { get; set; }
        public DbSet<Want_To_Guid> Want_To_Guids { get; set; }
        public DbSet<Want_To_Visit> Want_To_Visits { get; set; }

        public GuidMeContext() : base(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=GuidMeDbLocal;")
        {

        }
    }
}
