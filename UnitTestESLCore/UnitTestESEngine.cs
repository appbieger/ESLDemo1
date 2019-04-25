using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESLCore;

namespace UnitTestESLCore
{
    [TestClass]
    public class UnitTestESEngine
    {
 

        [TestMethod]
        public void TestESEngine_Init()
        {
            ESEngine e = new ESEngine("demoURL", "demoShortCut", "initDisplayName", "initID");
            Assert.IsNotNull(e);
            Assert.AreEqual(e.GetID(), "initID");
            Assert.AreEqual(e.GetURL(), "demoURL");
            Assert.AreEqual(e.GetShortCut(), "demoShortCut");
            Assert.AreEqual(e.GetName(), "initDisplayName");
        }
    }
}
