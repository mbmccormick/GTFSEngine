#region using
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stancer.GTFSEngine.Entities;
#endregion
namespace Stancer.GTFSEngine.Test
{
    [TestClass]
    public class Test_Engine
    {
        private Engine mEngine;

        [TestInitialize]
        public void Init()
        {
            mEngine = new Engine();

            mEngine.LoadFromAssembly(TransitFileType.Calendar,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.calendar.txt", GetType().Assembly);
            mEngine.LoadFromAssembly(TransitFileType.StopTimes,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.stop_times.txt", GetType().Assembly);
            mEngine.LoadFromAssembly(TransitFileType.FareRules,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.fare_rules.txt", GetType().Assembly);
            mEngine.LoadFromAssembly(TransitFileType.CalendarDates,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.calendar_dates.txt", GetType().Assembly);
            mEngine.LoadFromAssembly(TransitFileType.Trips,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.trips.txt", GetType().Assembly);
            mEngine.LoadFromAssembly(TransitFileType.Agency,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.agency.txt", GetType().Assembly);
            mEngine.LoadFromAssembly(TransitFileType.Stops,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.stops.txt", GetType().Assembly);
            mEngine.LoadFromAssembly(TransitFileType.Agency,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.agency.txt", GetType().Assembly);
            mEngine.LoadFromAssembly(TransitFileType.Shapes,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.shapes.txt", GetType().Assembly);
            mEngine.LoadFromAssembly(TransitFileType.FareAttributes,
                "Stancer.GTFSEngine.Test.TestData.Caltrain.fare_attributes.txt", GetType().Assembly);

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
            var a1 = mEngine.CalendarDates.First();
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
