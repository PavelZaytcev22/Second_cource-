using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _12LabLibrary;

namespace _12LabUnitTests
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Point<int> c1 = new Point<int>(5);
            Point<int> c2 = new Point<int>(5);
            Assert.IsTrue(c1.Equals(c2));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Point<int> c1 = new Point<int>(5);
            c1.NextPoint=null;
            c1.NextPoint = new Point<int>(5);
            Assert.IsTrue(c1.Value.Equals(c1.NextPoint.Value));
        }

        [TestMethod]
        
        public void TestMethod3()
        {
            Point<int> c1 = new Point<int>(5);
            c1.NextPoint = null;
            c1.NextPoint = new Point<int>(5);
            Assert.IsTrue(c1.Value.Equals(c1.NextPoint.Value));
        }

        [TestMethod]
        
        public void TestMethod4()
        {
            Point<int> c1 = new Point<int>(5);
            c1.NextPoint = null;
            c1.NextPoint = new Point<int>(5);
            Assert.IsTrue(c1.Value.Equals(c1.NextPoint.Value));
        }

    }
}
