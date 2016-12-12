using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvaluation { get; set; }

        [MaxLength(20), MinLength(1)]
        public String Gui_Pseudo { get; set; }
        public virtual Person PseudoGuide { get; set; }

        [MaxLength(20), MinLength(1)]
        public String Visit_Pseudo { get; set; }
        public virtual Person PseudoVisitor { get; set; }

        [Range(typeof(decimal), "0", "5")]
        public decimal Eval { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
