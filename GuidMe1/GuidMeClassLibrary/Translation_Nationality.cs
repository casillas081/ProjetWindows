using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class Translation_Nationality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTranslationNationality { get; set; }

        [Required]
        [MaxLength(15), MinLength(1)]
        public String TranslationNationatity { get; set; }

        [MaxLength(6), MinLength(1)]
        public String IdLanguage { get; set; }
        public virtual LanguagePerson CodeLanguage { get; set; }

        [MaxLength(20), MinLength(1)]
        public String IdPerson { get; set; }
        public virtual Person person { get; set; }
    }
}
