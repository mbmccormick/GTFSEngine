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
    public class Test_Engine_NewYork : Test_Engine
    {

        [TestInitialize]
        public void Init()
        {
            AssemblySourceDataCollection dc =
                new AssemblySourceDataCollection(GetType().Assembly, "Stancer.GTFSEngine.Test.TestData.New_York", false);

            dc.HasCalendarDates = true;
            dc.HasFareAttributes = false;
            dc.HasFareRules = false;
            dc.HasFrequencies = false;
            dc.HasShapes = true;
            dc.HasTransfers = true;

            mEngine = new Engine(dc);
        }

    }
}
