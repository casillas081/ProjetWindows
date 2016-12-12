using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class TranslationPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTraslationPlace { get; set; }

        [Required]
        [MaxLength(30), MinLength(1)]
        public String TranslationNamePlace { get; set; }

        [MaxLength(6), MinLength(1)]
        public String IdLanguage { get; set; }
        public virtual LanguagePerson CodeLanguage { get; set; }

        [MaxLength(20), MinLength(1)]
        public String IdPlace { get; set; }
        public virtual Place Places { get; set; }


    }
}
