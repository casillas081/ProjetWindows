using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class Want_To_Guid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWantToGuid { get; set; }

        [MaxLength(20), MinLength(1)]
        public String IdPerson { get; set; }
        public virtual Person person { get; set; }

        [MaxLength(20), MinLength(1)]
        public String IdPlace { get; set; }
        public virtual Place place { get; set; }
    }
}
