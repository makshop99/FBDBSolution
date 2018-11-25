using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FBDBLibUnit.view
{
    [TestClass]
    public class UnitTest_FBDBLibInterface
    {
        [TestMethod]
        public void Test_init()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();

            int iReturn = oPruefling.init("");

            Assert.AreEqual(iReturn, 0);

        }
    }


}
