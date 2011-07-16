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
    public abstract class Test_Engine
    {
        protected Engine mEngine;

        [TestMethod]
        public void Test_Agency()
        {
            var a1 = mEngine.Agencies.Last();
        }

        [TestMethod]
        public void Test_Calendar()
        {
            var a1 = mEngine.Calendars.Last();
        }

        [TestMethod]
        public void Test_CalendarDates()
        {
            var a1 = mEngine.Calendar_Dates.Last();
        }

        [TestMethod]
        public void Test_Fare_Attributes()
        {
            var a1 = mEngine.Fare_Attributes.Last();
        }

        [TestMethod]
        public void Test_Routes()
        {
            var a1 = mEngine.Routes.Last();
        }

        [TestMethod]
        public void Test_Shapes()
        {
            var a1 = mEngine.Shapes.Last();
        }
    }
}