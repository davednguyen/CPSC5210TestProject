using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CPSC5210TestProject
{
    [TestClass]
    public class MainUnitTest
    {
        [TestMethod]
        public void FirstTest()
        {
            Functions mainFunction = new Functions();
            var total = mainFunction.SumOfTwoValues(20, 45);
            Assert.AreEqual(65, total);
        }
    }
}
