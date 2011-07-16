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
    public class Test_Engine_Caltrain : Test_Engine
    {

        [TestInitialize]
        public void Init()
        {

            ResourceSourceDataCollection dc =
                new ResourceSourceDataCollection(Stancer.Win7Trans.Resources.Caltrain.Properties.Resources.ResourceManager);

            //dc.HasCalendarDates = true;
            //dc.HasFareAttributes = true;
            //dc.HasFareRules = true;
            //dc.HasFrequencies = false;
            //dc.HasShapes = true;
            //dc.HasTransfers = false;

            mEngine = new Engine(dc);
        }

    }
}
