using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class LanguagePerson
    {
        [Key]
        public String CodeLanguage { get; set; }
        [Required]
        [MaxLength(10), MinLength(1)]
        public String Name { get; set; }
    }
}
