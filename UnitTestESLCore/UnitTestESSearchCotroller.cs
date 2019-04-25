using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESLCore;

namespace UnitTestESLCore
{
    [TestClass]
    public class UnitTestESSearchCotroller_
    {

        [TestMethod]
        public void TestESSearchCotroller_Init()
        {
            Assert.IsNotNull(new ESSearchController());
        }

        [TestMethod]
        public void TestESSearchCotroller_InitDefaults()
        {
            ESSearchController se = new ESSearchController();
            Assert.IsNotNull(se.DefaultEngine);
        }


        [TestMethod]
        public void TestESSearchCotroller_EngineByID()
        {
            ESSearchController se = new ESSearchController();
            Assert.IsNotNull(se);

            Assert.IsNotNull(se.GetEngineByID("com.stackoverflow"));
            Assert.IsNotNull(se.GetEngineByID("com.volkswagenag.groupfind"));
            Assert.IsNotNull(se.GetEngineByID("com.google"));
            Assert.IsNotNull(se.GetEngineByID("com.bing"));
            Assert.IsNotNull(se.GetEngineByID("org.wikipedia.de"));
            Assert.IsNotNull(se.GetEngineByID("com.stackoverflow"));

            Assert.IsNull(se.GetEngineByID("com.DEMO.DEMO"));
        }

        [TestMethod]
        public void TestESSearchCotroller_EngineByString()
        {
            ESSearchController se = new ESSearchController();
            Assert.IsNotNull(se);

            Assert.AreEqual(se.GetEngineByString("gf:tt").GetID(), "com.volkswagenag.groupfind");
            Assert.AreEqual(se.GetEngineByString("go:tt").GetID(), "com.google");
            Assert.AreEqual(se.GetEngineByString("wp:tt").GetID(), "org.wikipedia.de");

        }

        [TestMethod]
        public void TestESSearchCotroller_GetActionTextForText()
        {
            ESSearchController se = new ESSearchController();
            Assert.IsNotNull(se);

            Assert.AreEqual(se.GetActionTextFor("gf:tt") , "gf:tt - GroupFind");
            Assert.AreEqual(se.GetActionTextFor("go:tt") , "go:tt - Google");
            Assert.AreEqual(se.GetActionTextFor("wp:tt"), "wp:tt - Wikipedia");

            Assert.IsNotNull(se.GetActionTextFor("demo:tt"));
            Assert.IsNotNull(se.GetActionTextFor("demo"));
            Assert.IsNotNull(se.GetActionTextFor(null));

        }

        [TestMethod]
        public void TestESSearchCotroller_GetURLForSearchString()
        {
            ESSearchController se = new ESSearchController();
            Assert.IsNotNull(se);

            Assert.AreEqual(se.GetURLForSearchString("gf:t t"), "https://groupfind.volkswagenag.com/jctgroupfind/groupfind2/search?q=t%20t");
            Assert.AreEqual(se.GetURLForSearchString("go:t t"), "https://www.google.com/search?q=t%20t");
            Assert.AreEqual(se.GetURLForSearchString("wp:t t"), "https://en.wikipedia.org/w/index.php?search=t%20t");
            
            Assert.IsNotNull(se.GetURLForSearchString("t t"));
        }

        [TestMethod]
        public void TestESSearchCotroller_SelectPrevTest()
        {
            ESSearchController se = new ESSearchController();

            Assert.AreEqual("gf:t t", se.SelectPrev("gf:t t"));
            Assert.AreEqual("gf:t t", se.SelectPrev("go:t t"));
            Assert.AreEqual("go:t t", se.SelectPrev("bi:t t"));
            Assert.AreEqual("dd:t t", se.SelectPrev("wp:t t"));
            Assert.AreEqual("wp:t t", se.SelectPrev("so:t t"));
        }

        [TestMethod]
        public void TestESSearchCotroller_SelectNextTest()
        {
            ESSearchController se = new ESSearchController();
            
            Assert.AreEqual("gf:t t", se.SelectNext("t t"));
            Assert.AreEqual("go:t t", se.SelectNext("gf:t t"));
            Assert.AreEqual("bi:t t", se.SelectNext("go:t t"));
            Assert.AreEqual("wp:t t", se.SelectNext("dd:t t"));
            Assert.AreEqual("so:t t", se.SelectNext("wp:t t"));
            Assert.AreEqual("so:t t", se.SelectNext("so:t t"));
        }
    }
}

 