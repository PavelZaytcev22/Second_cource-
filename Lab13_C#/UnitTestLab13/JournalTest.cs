using _13LabLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestLab13
{
    [TestClass]
    public class JournalTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Journal c1 = new Journal();
            JournalEntry b2 = new JournalEntry("1", "23", "4");
            c1.Add(b2);
            Assert.IsTrue(b2.ToString() is string);
        }


    }

}
