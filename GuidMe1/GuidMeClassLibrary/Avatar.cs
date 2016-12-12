using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class Avatar
    {
        [Key]
        public String IdPicture { get; set; }
        [Required]
        [MaxLength(50), MinLength(4)]
        public String Name { get; set; }
        [Required]
        [MaxLength(200), MinLength(10)]
        public String UrlPicture { get; set; }
        
    }
}
