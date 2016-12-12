using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class Person
    {
        [Key]
        [MaxLength(20), MinLength(1)]
        public String Pseudo { get; set; }
        [Required]
        [MaxLength(30), MinLength(2)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(30), MinLength(2)]
        public String LastName { get; set; }
        [Required]
        public Boolean Sex { get; set; }
        [Required]
        [MaxLength(15), MinLength(20)]
        public String Nationality { get; set; }
        [Required]
        public Boolean TypeRole { get; set; }
        [Required]
        public Boolean IsActive { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "5")]
        public decimal RankGuid { get; set; }


        public String IdPicture { get; set; }
        public virtual Avatar avatar { get; set; }
    }
}
