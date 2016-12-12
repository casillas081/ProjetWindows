using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using GuidMeClassLibrary;
using System.Linq;

namespace UnitTestGuidMe
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Setup()
        {
            Database.SetInitializer(new DbInitializer());
                using (GuidMeContext context = GetContext())
                {
                    context.Database.Initialize(true);
                }

        }

        public GuidMeContext GetContext()
        {
            return new GuidMeContext();
        }

        [TestMethod]
        public void InsertionFonctionnelle()
        {
            using(var context = GetContext())
            {
                Assert.AreEqual(1, context.TranslationPlaces.ToList().Count);
            }
        }
    }
}
