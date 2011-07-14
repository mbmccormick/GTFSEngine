#region using
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stancer.GTFSEngine.Entities;

using Ximura;
#endregion
namespace Stancer.GTFSEngine.Test
{
    [TestClass]
    public class Test_Engine_Caltrain
    {
        private Engine mEngine;

        [TestInitialize]
        public void Init()
        {
            AssemblySourceDataCollection dc =
                new AssemblySourceDataCollection(GetType().Assembly, "Stancer.GTFSEngine.Test.TestData.Caltrain", false);

            dc.HasCalendarDates = true;
            dc.HasFareAttributes = true;
            dc.HasFareRules = true;
            dc.HasFrequencies = false;
            dc.HasShapes = true;
            dc.HasTransfers = false;

            mEngine = new Engine();
            mEngine.Load(dc);


        }

        [TestMethod]
        public void Test_Agency()
        {
            var a1 = mEngine.Agencies.First();
        }

        [TestMethod]
        public void Test_Calendar()
        {
            var a1 = mEngine.Calendars.First();
        }

        [TestMethod]
        public void Test_CalendarDates()
        {
            var a1 = mEngine.Calendar_Dates.First();
        }

        [TestMethod]
        public void Test_Fare_Attributes()
        {
            var a1 = mEngine.Fare_Attributes.First();
        }

        [TestMethod]
        public void Test_Routes()
        {
            var a1 = mEngine.Routes.First();
        }

        [TestMethod]
        public void Test_Shapes()
        {
            var a1 = mEngine.Shapes.First();
        }
    }
}
