using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESLCore;

namespace UnitTestESLCore
{
    [TestClass]
    public class UnitTestESLAppHandler
    {
   

        [TestMethod]
        public void TestESLAppHandler_Init()
        {
            Assert.IsNotNull(new ESLAppHandler());
        }



    }
}
