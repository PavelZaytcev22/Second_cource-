using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _10LabLibrary;
using System.Security.Cryptography;
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;

namespace TestsFor10Lab
{
    [TestClass]
    public class UnitTestClasses
    {
        [TestMethod]
        public void TestMethod1()
        {
            Test c1 = new Test();
            c1.Name = "Математика";
            c1.Questions = -5;//Неверная инициализация
            c1.Questions = 20;
            c1.Date = "10/23/41";
            c1.Teacher ="Боброва";
            Test c2 = new Test("Математика",20,"10/23/41", "Боброва");
            Assert.IsTrue(c1.Equals(c2));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Test c1 = new Test();
            Test c2 = new Test("Математика", 40,"10/23/41", "Боброва");
            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Test e1 = new Test("Математика", 1, "10/23/41", "Боброва");
            Test c1 = new Test();
            Assert.IsTrue(c1.CompareTo(e1) == 0);
        }


        [TestMethod]
        public void TestMethod4()
        {
            Exam e1 = new Exam("Математика", 40, "10/23/41", 34);
            Test c1 = new Test();
            Assert.IsTrue(c1.CompareTo(e1) == -1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            FinalExam e11 = new FinalExam("Математика", 40, "10/23/41", 34,4);
            Test c1 = new Test();
            Assert.IsTrue(c1.CompareTo(e11) == -1);
        }

     

        [TestMethod]
        public void TestMethod7()
        {
            FinalExam c1 = new FinalExam();
            Exam c2 = new Exam();
            Assert.IsTrue(c2.Equals(c1.BaseExam));
        }

        [TestMethod]
        public void TestMethod8()
        {
            Exam c1 = new Exam();
            c1.Name = "Математика";
            c1.Questions = -40;// Неверная инициализация
            c1.Questions = 40;
            c1.Date = "10/23/41";
            c1.Time = 34;
            Exam c2 = new Exam("Математика", 40, "10/23/41", 34);
            Assert.IsTrue(c1.Equals(c2));
        }

        [TestMethod]
        public void TestMethod9()
        {
            Exam c1 = new Exam();
            Exam c2 = new Exam();
            c2.Date = "12/32";
            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void TestMethod10()
        {
            Challenge c1 = new Challenge();
            Assert.IsFalse(c1.Equals(new Challenge("111",23,"vsdfs")));
        }


        [TestMethod]
        public void TestMethod11()
        {
            Exam c1 = new Exam();
            Exam c2 = new Exam();
            Assert.IsTrue(c1.CompareTo(c2) == 0);
        }

        [TestMethod]
        public void TestMethod12()
        {
            Exam c1 = new Exam();
            FinalExam c2 = new FinalExam();
            Assert.IsTrue(c1.CompareTo(c2) == 0);
        }

        [TestMethod]
        public void TestMethod13()
        {
            Exam c1 = new Exam();
            Test c2 = new Test();
            Assert.IsTrue(c1.CompareTo(c2) == 0);
        }

        

        [TestMethod]
        public void TestMethod15()
        {
            Challenge c1 = new Challenge();
            Assert.IsTrue(c1.Equals(new Challenge()));
        }

        [TestMethod]
        public void TestMethod16()
        {
            FinalExam c1 = new FinalExam();
            c1.Name = "Математика";
            c1.Questions = -40;// Неверная инициализация
            c1.Questions = 40;
            c1.Mark = -5;
            c1.Mark = 3;
            c1.Date = "12/03/45";
            c1.Time = -5;
            c1.Time = 34;
            FinalExam c2 = new FinalExam("Математика", 40, "12/03/45",34,3);
            Assert.IsTrue(c1.Equals(c2));
        }

        [TestMethod]
        public void TestMethod17() 
        {
            FinalExam c1 = new FinalExam();
            FinalExam c2 = new FinalExam("Математика", 40, "12/03/45", 34, 3);
            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void TestMethod18()
        {
            FinalExam c1 = new FinalExam();
            Exam c2 = new Exam();
            Assert.IsTrue(c1.CompareTo(c2) == 0);
        }

        [TestMethod]
        public void TestMethod19()
        {
            FinalExam c1 = new FinalExam();
            FinalExam c2 = new FinalExam();
            Assert.IsTrue(c1.CompareTo(c2) == 0);
        }
        [TestMethod]
        public void TestMethod20()
        {
            FinalExam c1 = new FinalExam();
            Test c2 = new Test();
            Assert.IsTrue(c1.CompareTo(c2) == 0);
        }

        


        [TestMethod]
        public void TestMethod23()
        {
            SuperTest c1 = new SuperTest();
            c1.People = 54;
            SuperTest c2 = new SuperTest("Математика", 40, "10/23/41", "  ", 54);
            Assert.IsTrue(c1.People == c2.People);
        }

        [TestMethod]
        public void TestMethod24()//Тестирование клонирования 
        {
            SuperTest c1 = new SuperTest();
            c1.People = 43; 
            SuperTest c2 = (SuperTest)c1.Clone();
            SuperTest c3 = c1.ShallowCopy();
            Assert.IsTrue(c1.People==c3.People);
        }

      /*  [TestMethod]
        public void TestMethod25()
        {
            FinalExam c1 = new FinalExam();
            Assert.IsTrue("?10"==c1.ToString());
        }*/


        [TestMethod]
        public void TestMethod26()
        {
            Challenge c1 = new Challenge();
            Challenge c2 = new Challenge();
            ChallengeCoparer c5 = new ChallengeCoparer();
            Assert.IsTrue(c5.Compare(c1,c2)==0);
        }

      

    }
}
