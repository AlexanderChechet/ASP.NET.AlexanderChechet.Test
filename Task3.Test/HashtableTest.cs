using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task3.Test
{
    [TestClass]
    public class HashtableTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HashtableTest_AddException()
        {
            Hashtable<int, int> table = new Hashtable<int, int>();
            table.Add(1, 100);
            table.Add(1, 100);
        }

        [TestMethod]
        public void HashtableTest_AddGet()
        {
            Hashtable<int, int> table = new Hashtable<int, int>();
            table.Add(1, 100);
            table.Add(2, 200);

            var result = table.Get(2);

            Assert.AreEqual(200, result);
        }

        [TestMethod]
        public void HashtableTest_UserFunc()
        {
            Hashtable<int, int> table = new Hashtable<int, int>(x => x%10, EqualityComparer<int>.Default);
            table.Add(1, 100);
            table.Add(11, 100);
            table.Add(21, 100); 
            table.Add(31, 100); 
            table.Add(41, 100); 
            table.Add(51, 100); 
            table.Add(61, 100);

            int i = 0;
        }

        [TestMethod]
        public void HashtableTest_Foreach()
        {
            Hashtable<int, int> table = new Hashtable<int, int>();
            table.Add(1, 100);
            table.Add(2, 200);
            table.Add(3, 100);
            table.Add(4, 200);
            table.Add(5, 100);
            table.Add(6, 200);

            int result = 0;
            foreach (var item in table)
            {
                result += item;
            }
            table.Get(2);

            Assert.AreEqual(900, result);
        }
    }
}
