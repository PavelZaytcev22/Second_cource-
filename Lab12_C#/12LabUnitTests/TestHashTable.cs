using _12LabLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12LabUnitTests
{
    [TestClass]
    public class TestHashTable
    {
        [TestMethod]
        public void Test1() 
        {
            HashTable<int> c1 = new HashTable<int>();
            c1 = new HashTable<int>(-3);
            c1 = new HashTable<int>(4);
            HashTable<int> v1 = c1.ShallowCopy();
            v1 = new HashTable<int>(c1);
            v1.Add(55);
            v1.Add(55);
            v1.Add(55);
            v1.Clear();
            Assert.IsFalse(c1.Contains(55));
        }

        [TestMethod]
        public void Test2()
        {
            HashTable<string> c1 = new HashTable<string>();
            Assert.IsFalse(c1.Contains(""));           
        }

        [TestMethod]
        public void Test3()
        {
            HashTable<string> c1 = new HashTable<string>(4);
            c1.Add("vvv");
            Assert.IsFalse(c1.Contains(""));
        }

        [TestMethod]
        public void Test4()
        {
            HashTable<string> c1 = new HashTable<string>(0);
            Assert.IsFalse(c1.Remove(""));
        }

        [TestMethod]
        public void Test5()
        {
            HashTable<string> c1 = new HashTable<string>(3);
            c1.Add("cc");
            Assert.IsTrue(c1.Remove("cc"));
        }

        [TestMethod]
        public void Test6()
        {
            HashTable<string> c1 = new HashTable<string>(3);
            c1.Add("cc");
            Assert.IsTrue(c1.Count==1);
        }

        [TestMethod]
        public void Test7()
        {
            HashTable<string> c1 = new HashTable<string>(3);
            Assert.IsTrue(c1.Length == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test8()
        {
            HashTable<string> c1 = new HashTable<string>(3);
            ListPoints<string> c2 = c1[6];
        }

        [TestMethod]
        public void Test9()
        {
            HashTable<string> c1 = new HashTable<string>(1);
            ListPoints<string> c2 = c1[0];
            Assert.IsTrue(c2.Count == 0);
        }


        [TestMethod]
        public void Test10()
        {
            HashTable<string> c1 = new HashTable<string>(4);
            foreach (var i in c1) { }
            HashEnumerator < string >  vv= new HashEnumerator<string>(c1);
            vv.Reset();
            Assert.IsTrue(c1.IsReadOnly);
        }

        [TestMethod]
        public void Test11()
        {
            HashTable<string> c1 = new HashTable<string>(4);
            HashTable<string> c2 = (HashTable<string>)c1.Clone();
            Assert.IsTrue(c1.Count==c2.Count);
        }



    }
}
