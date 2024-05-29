using _13LabLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10LabLibrary;
using _12LabLibrary;

namespace UnitTestLab13
{
    [TestClass]
    public class NewHashTableTest
    {

        [TestMethod]
        public void Test1()
        {
            MyHashTable c1 = new MyHashTable();
             c1 = new MyHashTable(3);
            c1.Clear();
            c1.Add(new Challenge("13", 22, "323"));
            c1.Remove(new Challenge("13", 22, "323"));
            int v = c1.Length;
            v = c1.Count;
            MyHashTable c2 = new MyHashTable(-3);
            c2 = new MyHashTable(3);
            c2.Add(new Challenge("13",22,"323"));
            Assert.IsTrue(c2.Contains(new Challenge("13", 22, "323")));
        }

        [TestMethod]
        public void Test2()
        {
            MyHashTable c2 = new MyHashTable(3);
            c2.Add(new Challenge("13", 22, "323"));
            Assert.IsTrue(c2[0] is ListPoints<Challenge>);

        }


        [TestMethod]
        public void Test3()
        {
            MyNewHashTable c2 =new MyNewHashTable();
            c2 = new MyNewHashTable("",0);
            c2.Add(new Challenge("13", 22, "323"));
            c2 = new MyNewHashTable("First", -1);
            c2 = new MyNewHashTable("First",1);
            c2.Add(new Challenge("13", 22, "323"));
            Assert.IsTrue(c2[0] is ListPoints<Challenge>);
        }

        [TestMethod]
        public void Test4()
        {
            MyNewHashTable c2 = new MyNewHashTable("",0);
            c2.AddRandom();
            c2 = new MyNewHashTable("First", 1);
            Journal v1 = new Journal();
           
            c2.AddRandom();
            c2.AddRandom();
            c2.AddRandom();
            c2.AddRandom();
            c2.Remove(1);
            c2.Remove(1);
            c2.Remove(10);
            c2[0,0] = null;
            Assert.IsTrue(c2[0,0] is null);
        }

        [TestMethod]
        public void Test5() 
        {
           MyNewHashTable c2 = new MyNewHashTable("First", 1);
            c2.Name = "VVV";
            Journal v1 = new Journal();
            c2.CollectionCountChanged += new CollectionHandler(v1.CollectionCountChanged);
            c2.CollectionReferenceChanged += new CollectionHandler(v1.CollectionReferenceChanged);
            c2.AddRandom();
            c2.AddRandom();
            c2[0, 0] = null;
            Assert.IsTrue(c2[0, 0] is null);
        }

    }
}
