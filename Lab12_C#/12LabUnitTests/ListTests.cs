using _12LabLibrary;
using _10LabLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _12LabUnitTests
{
    [TestClass]
    public  class ListTests
    {
        [TestMethod]
        public void TestMethood1() 
        {
            ListPoints<int> c1 = new ListPoints<int>();
            ListPoints<int> c2 = new ListPoints<int>(c1);
            c1.Clear();
            Assert.IsTrue(c1.Head==c2.Head);
        }

        [TestMethod]
        public void TestMethood2()
        {
            ListPoints<int> c1 = new ListPoints<int>(25);
            c1.Add(43);
            ListPoints<int> c2 = new ListPoints<int>(c1);
            Assert.IsTrue(c1.Head.Value.Equals(c2.Head.Value));
        }

        [TestMethod]
        public void TestMethood3()
        {
            ListPoints<int> c1 = new ListPoints<int>(25);
            c1.Add(43);
            Assert.IsTrue(c1.Contains(25));
        }

        [TestMethod]
        public void TestMethood4()
        {
            ListPoints<int> c1 = new ListPoints<int>(25);
            c1.Add(43);
            Assert.IsFalse(c1.Contains(0));
        }

        [TestMethod]
        public void TestMethood5()
        {
            ListPoints<int> c1 = new ListPoints<int>(25);
            c1.Add(43);
            Assert.IsFalse(c1.Remove(0));
        }

        [TestMethod]
        public void TestMethood6()
        {
            ListPoints<int> c1 = new ListPoints<int>(25);
            c1.Add(43);
            Assert.IsTrue(c1.Remove(25));
        }

        [TestMethod]
        public void TestMethood7()
        {
            ListPoints<int> c1 = new ListPoints<int>(25);
            Assert.IsTrue(c1.Remove(25));
        }

        [TestMethod]
        public void TestMethood8()
        {
            ListPoints<int> c1 = new ListPoints<int>();
            Assert.IsTrue(c1.Count==0);
        }

        [TestMethod]
        public void TestMethood9()
        {
            ListPoints<int> c1 = new ListPoints<int>(10);
            c1.Add(44);
            Assert.IsTrue(c1.Count == 2);
        }

        [TestMethod]
        public void TestMethood10()
        {
            ListPoints<int> c1 = new ListPoints<int>(10);
            Assert.IsTrue(c1.IsReadOnly);
        }

        [TestMethod]
        public void TestMethood11()
        {
            ListPoints<int> c1 = new ListPoints<int>(59);
            c1.Add(444);
            foreach(var i in c1) { }
            MyEnumerator<int> v1 = new MyEnumerator<int>(c1);
            v1.Reset();
            Assert.IsTrue(v1 is MyEnumerator<int>);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethood12()
        {
            ListPoints<int> c1 = new ListPoints<int>(59);
            c1.Add(1);
            c1.Add(1);
            c1.Add(1);
            c1[2] = 33;
            c1[100]=300;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethood13()
        {
            ListPoints<int> c1 = new ListPoints<int>(59);
            c1.Add(1);
            c1.Add(1);
            c1.Add(1);
            int v1 = c1[2];
            v1 = c1[100];            
        }

        [TestMethod]
        public void TestMethood14()
        {
            ListPoints<int> c1 = new ListPoints<int>(59);
            c1.Add(1);
            c1.Add(1);
            c1.Remove(1);
            c1.Remove(1);
            c1.Add(1);
            c1.Add(1);
            Assert.IsTrue(c1.Contains(1));
        }

        [TestMethod]
        public void TestMethood15()
        {
            ListPoints<Challenge > c1 = new ListPoints<Challenge>();
            Challenge buff = new Challenge();
            buff.RandomInit();
            c1.Add(new Challenge(buff));
            buff.RandomInit();
            c1.Add(new Challenge(buff));
            buff.RandomInit();
            c1.Add(new Challenge(buff));
            c1.Clear();
            buff.RandomInit();
            c1.Add(new Challenge(buff));
            buff.RandomInit();
            c1.Add(new Challenge(buff));
            Assert.IsTrue(c1.Contains(buff));
        }


    }
}
