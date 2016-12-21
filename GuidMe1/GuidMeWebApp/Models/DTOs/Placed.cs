using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace GuidMeWebApp.Models.DTOs
{
    public class Placed
    {
        public String IdPlace { get; set; }
        public String Address { get; set; }
        public DbGeography Position { get; set; }
    }
}