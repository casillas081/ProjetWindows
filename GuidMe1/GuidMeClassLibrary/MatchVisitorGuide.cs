using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class MatchVisitorGuide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMatchVisitorGuide { get; set; }

        [MaxLength(20), MinLength(1)]
        public String Gui_Pseudo { get; set; }
        public virtual Person PseudoGuide { get; set; }

        [MaxLength(20), MinLength(1)]
        public String Visit_Pseudo { get; set; }
        public virtual Person PseudoVisitor { get; set; }

        [Required]
        public DateTime DateRelation { get; set; }

        [Required]
        [MaxLength(30), MinLength(1)]
        public String NamePlace { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
