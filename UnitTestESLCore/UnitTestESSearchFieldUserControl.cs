using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 
using ESLCore;
using System.Windows;

namespace UnitTestESLCore
{
    class MockESSearchController : ESSearchControllerInterface
    {
        public string MGetActionTextFor;
        public string MGetActionTextFor_RET = "";
        public string GetActionTextFor(string v)
        {
            MGetActionTextFor = v;
            return MGetActionTextFor_RET;
        }

        public string MSelectNext;
        public string MSelectNext_ret = "";
        public string SelectNext(string v)
        {
            MSelectNext = v;
            return MSelectNext_ret;
        }

        public string MSelectPrev;
        public string MSelectPrev_ret = "";
        public string SelectPrev(string v)
        {
            MSelectPrev = v;
            return MSelectPrev_ret;
        }

        public string MGetURLForSearchString;
        public string MGetURLForSearchString_RET = "";
        public string GetURLForSearchString(string v)
        {
            MGetURLForSearchString = v;
            return MGetURLForSearchString_RET;
        }
    }

    class MockESLAppHandler : ESLAppHandlerInterface
    {
        public bool MCloseApp = false;
  
        public void CloseApp(object win)
        {
            MCloseApp = true;
        }
        public string MOpenURL;
        public void OpenURL(string url)
        {
            MOpenURL = url;
        }
    }

    [TestClass]
    public class UnitTestESSearchFieldUserControl
    {
        [TestMethod]
        public void TestESUserControler_Init()
        {
            Assert.IsNotNull(new ESSearchFieldUserControl()); 
        }

        [TestMethod]
        public void TestESUserControler_IO()
        {
            ESSearchFieldUserControl xx = new ESSearchFieldUserControl();
            MockESSearchController m = new MockESSearchController();
            xx.SearchController = m;
            xx.Text = "TTS";

            Assert.AreEqual("TTS",xx.Text);
            xx.WhaterMarc = "TT";
            Assert.AreEqual("TT", xx.WhaterMarc);
        }

        [TestMethod]
        public void TestESUserControler_StartSearch()
        {
            MockESSearchController m = new  MockESSearchController ();
            MockESLAppHandler a = new MockESLAppHandler();
            ESSearchFieldUserControl es = new ESSearchFieldUserControl
            {
                SearchController = m
            };
            es.AppController = a;
            es.Text = "AppBieger";
          //  Assert.AreEqual(a.MOpenURL, "AppBieger");

           
            es.StartSearch();
        //    Assert.AreEqual(m.MStartSearch, "AppBieger");
        }
    }

  
}
