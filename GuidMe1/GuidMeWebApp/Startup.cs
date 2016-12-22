using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using GuidMeWebApp.Models;
using GuidMeWebApp.Models.Test;

[assembly: OwinStartup(typeof(GuidMeWebApp.Startup))]

namespace GuidMeWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Database.SetInitializer(new DbInitializer());
        }
    }
}
