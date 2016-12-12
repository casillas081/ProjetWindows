using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMeClassLibrary
{
    public class Place
    {
        [Key]
        public String IdPlace { get; set; }

        [Required]
        [MaxLength(100), MinLength(1)]
        public String Adresse { get; set; }

        [Required]
        public DbGeography Position { get; set; }
    }
}
