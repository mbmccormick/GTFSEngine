#region region
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ximura;
#endregion // region
namespace Stancer.GTFSEngine.Test
{
    [TestClass]
    public class Load
    {
        [TestMethod]
        public void TestMethod1()
        {
            byte[] test = new byte[] { 0xEF, 0xBB, 0xBF, 0x20 };
            int count = Encoding.UTF8.GetCharCount(test);

            //dataConv = new char[count];

            char[] dataConv = Encoding.UTF8.GetChars(test);

            using (Stream sData = this.GetType().Assembly.GetManifestResourceStream(
                "Stancer.GTFSEngine.Test.TestData.Caltrain.agency.txt"))
            {
                UnicodeCharEnumerator cEnum = new UnicodeCharEnumerator(sData);

                //char[] data = cEnum.
            }
        }
    }
}
