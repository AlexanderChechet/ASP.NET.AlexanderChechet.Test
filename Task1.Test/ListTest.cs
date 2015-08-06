using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Test
{
    [TestClass]
    public class ListTest
    {
        [TestMethod]
        public void ListTest_Contains()
        {
            Task1.List<int> list = new List<int>();
            list.Add(10);
            list.Add(12);
            list.Add(20);

            Assert.IsTrue(list.Contains(12));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ListTest_RemoveException()
        {
            Task1.List<int> list = new List<int>();
            list.Add(10);
            list.Add(12);
            list.Add(20);
            list.Remove(18);
        }

        [TestMethod]
        public void ListTest_Remove()
        {
            Task1.List<int> list = new List<int>();
            list.Add(10);
            list.Add(12);
            list.Add(20);
            list.Remove(20);

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void ListTest_Iterator()
        {
            Task1.List<int> list = new List<int>();
            list.Add(10);
            list.Add(12);
            list.Add(20);

            int summa = 0;
            foreach (var item in list)
            {
                summa += item;
            }

            Assert.AreEqual(42, summa);
        }
    }
}
