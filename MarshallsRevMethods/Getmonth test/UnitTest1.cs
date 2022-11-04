using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MarshallsRevenue;
namespace Getmonth_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestComputeRevenue()
        {
            int i = 10;
            int e = 23;
            int month = 5;
            
            double priceI = i * 500;
            double priceE = e * 750;
            double totalPrice = priceE + priceI;
            MarshallsRevenue.ComputeRevenue(month, i, e);
          //  Assert.AreEqual
        }
    }
}
