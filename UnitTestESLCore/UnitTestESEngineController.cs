using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESLCore;

namespace UnitTestESLCore
{
    [TestClass]
    public class UnitTestESEngineController_
    {
 

        [TestMethod]
        public void TestESEngineController_Init()
        {
            ESEngine e = new ESEngine("demoURL", "demoShortCut", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.IsNotNull(c);
        }


        [TestMethod]
        public void TestESEngineController_Static()
        {
            ESEngine e = new ESEngine("demoURL", "demoShortCut", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.AreEqual(ESEngineController.GetSeperator(), ":");
            Assert.AreEqual(c.GetSeperatorPosition(), 3);
            Assert.AreEqual(c.GetSearchActionSeperatorn(), " - ");
        }



        [TestMethod]
        public void TestESEngineController_ResponseToID()
        {
            ESEngine e = new ESEngine("demoURL", "demoShortCut", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.IsTrue(c.ResponseToID("initID"));
            Assert.IsFalse(c.ResponseToID("FalseinitID"));
        }

        [TestMethod]
        public void TestESEngineController_GetID()
        {
            ESEngine e = new ESEngine("demoURL", "demoShortCut", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.AreEqual(c.GetID(), "initID"); 
        }

        [TestMethod]
        public void TestESEngineController_ResponseToSearchString()
        {
            ESEngine e = new ESEngine("demoURL", "demoShortCut", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.IsTrue(c.ResponseToSearchString("demoShortCut:"));
            Assert.IsTrue(c.ResponseToSearchString("demoShortCut:test123"));
            Assert.IsTrue(c.ResponseToSearchString("demoShortCut:test1243"));
            Assert.IsTrue(c.ResponseToSearchString("DEMOShortCut:test1243"));


            Assert.IsFalse(c.ResponseToSearchString(null));
            Assert.IsFalse(c.ResponseToSearchString(""));
            Assert.IsFalse(c.ResponseToSearchString(":"));
            Assert.IsFalse(c.ResponseToSearchString("FalseDemoShortCut"));
            Assert.IsFalse(c.ResponseToSearchString("demoShortCut"));
        }

        [TestMethod]
        public void TestESEngineController_GetURL()
        {
            ESEngine e = new ESEngine("demoURL", "demoShortCut", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.AreEqual(c.GetURL("SearchString"), "demoURL" + "SearchString");
            Assert.AreEqual(c.GetURL(null), "demoURL");
            Assert.AreEqual(c.GetURL("Search String"), "demoURL" + "Search%20String");
            Assert.AreEqual(c.GetURL("demoShortCut:Search String"), "demoURL" + "demoShortCut:Search%20String");
        }

        [TestMethod]
        public void TestESEngineController_GetShortCutFromString()
        {
            ESEngine e = new ESEngine("demoURL", "gg", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.AreEqual(c.GetShortCutFromString("gg"), null);
            Assert.AreEqual(c.GetShortCutFromString("gg:test123"), "gg");
            Assert.AreEqual(c.GetShortCutFromString("gg:test1243"), "gg");
            Assert.AreEqual(c.GetShortCutFromString("gG:test1243"), "gG");
            Assert.AreEqual(c.GetShortCutFromString("GG:test1243"), "GG");
            Assert.AreEqual(c.GetShortCutFromString("DEMOShggortCut:test1243"), null);

            Assert.AreEqual(c.GetShortCutFromString(null), null);
            Assert.AreEqual(c.GetShortCutFromString(""), null);
            Assert.AreEqual(c.GetShortCutFromString(":"), null);
            Assert.AreEqual(c.GetShortCutFromString("FalseDemoShortCut"), null);
            Assert.AreEqual(c.GetShortCutFromString("demoShortCut"), null);
        }

        [TestMethod]
        public void TestESEngineController_GetSearchStringFromString()
        {
            ESEngine e = new ESEngine("demoURL", "gg", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.AreEqual(c.GetSearchStringFromString("gg"), "gg");
            Assert.AreEqual(c.GetSearchStringFromString("gg:test123"), "test123");
            Assert.AreEqual(c.GetSearchStringFromString("gg:test1243"), "test1243");
            Assert.AreEqual(c.GetSearchStringFromString("gG:test1243"), "test1243");
            Assert.AreEqual(c.GetSearchStringFromString("GG:test1243"), "test1243");
            Assert.AreEqual(c.GetSearchStringFromString("DEMOShggortCut:test1243"), "DEMOShggortCut:test1243");

            Assert.AreEqual(c.GetSearchStringFromString(null), null);
            Assert.AreEqual(c.GetSearchStringFromString(""), "");
            Assert.AreEqual(c.GetSearchStringFromString(":"), ":");
            Assert.AreEqual(c.GetSearchStringFromString("FalseDemoShortCut"), "FalseDemoShortCut");
            Assert.AreEqual(c.GetSearchStringFromString("demoShortCut"), "demoShortCut");
        }


        

        [TestMethod]
        public void TestESEngineController_GetActionStringFromString()
        {
            ESEngine e = new ESEngine("demoURL", "gg", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.AreEqual(c.GetActionString(null), "initDisplayName");
            Assert.AreEqual(c.GetActionString(""), "initDisplayName");
            Assert.AreEqual(c.GetActionString("1"), "1 - initDisplayName");
            Assert.AreEqual(c.GetActionString("gg:"), "gg: - initDisplayName");
            Assert.AreEqual(c.GetActionString("gg:test123"), "gg:test123 - initDisplayName");
            Assert.AreEqual(c.GetActionString("gg:test1243"), "gg:test1243 - initDisplayName");
            Assert.AreEqual(c.GetActionString("DEMOShggortCut:test1243"), "DEMOShggortCut:test1243 - initDisplayName");
        }

       
        [TestMethod]
        public void TestESEngineController_GetSearchStringWithShortcut()
        {
            ESEngine e = new ESEngine("demoURL", "gg", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.AreEqual(c.GetCompleatSearchString(null), "gg:");
            Assert.AreEqual(c.GetCompleatSearchString(""), "gg:");
            Assert.AreEqual(c.GetCompleatSearchString("1"), "gg:1");
            Assert.AreEqual(c.GetCompleatSearchString("gg:"), "gg:");
            Assert.AreEqual(c.GetCompleatSearchString("gg:test123"), "gg:test123");
            Assert.AreEqual(c.GetCompleatSearchString("gg:test1243"), "gg:test1243"); 
        }
        
        [TestMethod]
        public void TestESEngineController_IsResondingToShortCutt()
        {
            ESEngine e = new ESEngine("demoURL", "gg", "initDisplayName", "initID");
            ESEngineController c = new ESEngineController(e);

            Assert.AreEqual(c.IsResondingToShortCut(null), false);
            Assert.AreEqual(c.IsResondingToShortCut(""), false);
            Assert.AreEqual(c.IsResondingToShortCut("1"),false);
            Assert.AreEqual(c.IsResondingToShortCut("gg:"),true);
            Assert.AreEqual(c.IsResondingToShortCut("gg:test123"), true);
            Assert.AreEqual(c.IsResondingToShortCut("gg:test1243"), true);
        }


    }
}
