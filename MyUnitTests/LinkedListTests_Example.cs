using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;
using AlgoDataStructures.LinkedList;

namespace LinkedListTester
{
    [TestClass]
    public class LinkedListTests
    {
        private SingleLinkedList<int> CreateSLLOne()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(24);

            return sll;
        }

        private SingleLinkedList<int> CreateSLLTen()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            sll.Add(24);
            sll.Add(3);
            sll.Add(6);
            sll.Add(0);
            sll.Add(6);
            sll.Add(17);
            sll.Add(100);
            sll.Add(2014);
            sll.Add(122778);
            sll.Add(42);

            return sll;
        }

        private DoubleLinkedList<int> CreateDLLOne()
        {
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            dll.Add(24);

            return dll;
        }

        private DoubleLinkedList<int> CreateDLLTen()
        {
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            dll.Add(24);
            dll.Add(3);
            dll.Add(6);
            dll.Add(0);
            dll.Add(6);
            dll.Add(17);
            dll.Add(100);
            dll.Add(2014);
            dll.Add(122778);
            dll.Add(42);

            return dll;
        }

        protected string ArrayToString(int[] a)
        {
            StringBuilder sb = new StringBuilder();

            if (a.Length > 0)
            {
                sb.Append(a[0]);
                for (int i = 1; i < a.Length; i++)
                {
                    sb.Append(", ");
                    sb.Append(a[i]);
                }

            }

            return sb.ToString();
        }

        // This test method only exists so you can check that all your method signature match requirements
        [TestMethod]
        public void SLL_Methods()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Insert(1, 0);
            var count = list.Count;
            var value = list.Get(0);
            var removed = list.Remove();
            var last = list.RemoveLast();
            var listString = list.ToString();
            list.Clear();
            var index = list.Search(1);
        }

        [TestMethod]
        public void SLL_EmptyList()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            int expectedCount = 0;
            int actualCount = list.Count;

            string expectedString = "";
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfOne()
        {
            SingleLinkedList<int> list = CreateSLLOne();
            int expectedCount = 1;
            string expectedString = "24";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfOne_Remove()
        {
            SingleLinkedList<int> list = CreateSLLOne();
            int expectedReturn = 24;
            int expectedCount = 0;
            string expectedString = "";

            int actualReturn = list.Remove();
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_Remove()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 24;
            int expectedCount = 9;
            string expectedString = "3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Remove();
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_RemoveAll()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            List<int> vals = new List<int>() { 24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42 };
            int expectedReturn = 0;
            int expectedCount = 9;
            string expectedString;

            for (int i = 0; i < 10; i++)
            {
                expectedReturn = vals[0];
                vals.RemoveAt(0);
                expectedCount = vals.Count;
                expectedString = ArrayToString(vals.ToArray());

                int actualReturn = list.Remove();
                int actualCount = list.Count;
                string actualString = list.ToString();

                Assert.AreEqual(expectedReturn, actualReturn);
                Assert.AreEqual(expectedCount, actualCount);
                Assert.AreEqual(expectedString, actualString);
            }
        }

        [TestMethod]
        public void SLL_ListOfTen_RemoveThenAdd()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            list.Remove();
            list.Add(404);
            int expectedCount = 10;
            string expectedString = "3, 6, 0, 6, 17, 100, 2014, 122778, 42, 404";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_RemoveAt0()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 24;
            int expectedCount = 9;
            string expectedString = "3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.RemoveAt(0);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_RemoveAt5()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 17;
            int expectedCount = 9;
            string expectedString = "24, 3, 6, 0, 6, 100, 2014, 122778, 42";

            int actualReturn = list.RemoveAt(5);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_RemoveAt9()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 42;
            int expectedCount = 9;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778";

            int actualReturn = list.RemoveAt(9);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void SLL_ListOfTen_RemoveAt10Exception()
        {
            SingleLinkedList<int> list = CreateSLLTen();

            int actualReturn = list.RemoveAt(10);
        }

        [TestMethod]
        public void SLL_ListOfTen_InsertAt0()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedCount = 11;
            string expectedString = "711, 24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            list.Insert(711, 0);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_InsertAt5()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedCount = 11;
            string expectedString = "24, 3, 6, 0, 6, 711, 17, 100, 2014, 122778, 42";

            list.Insert(711, 5);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_InsertAt9()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedCount = 11;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 711, 42";

            list.Insert(711, 9);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void SLL_ListOfTen_InsertAt10Exception()
        {
            SingleLinkedList<int> list = CreateSLLTen();

            list.Insert(711, 10);
        }

        [TestMethod]
        public void SLL_ListOfTen_GetAt0()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 24;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Get(0);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_GetAt5()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 17;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Get(5);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_GetAt9()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 42;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Get(9);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void SLL_ListOfTen_GetAt10Exception()
        {
            SingleLinkedList<int> list = CreateSLLTen();

            list.Get(10);
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueAtHead()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 0;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Search(24);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueAtTail()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 9;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Search(42);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueAppearsTwice()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 2;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Search(6);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueNotInList()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = -1;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Search(999);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueInEmptyList()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            int expectedReturn = -1;
            int expectedCount = 0;
            string expectedString = "";

            int actualReturn = list.Search(24);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_Clear()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            list.Clear();
            int expectedCount = 0;
            string expectedString = "";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        //[TestMethod]
        //public void DLL_CountTest()
        //{
        //    DoubleLinkedList<int> list = new DoubleLinkedList<int>();

        //    // Empty List
        //    int expectedCount = 0;
        //    int actualCount = list.Count;
        //    Assert.AreEqual(expectedCount, actualCount);

        //    // After Add
        //    list.Add(1);
        //    expectedCount = 1;
        //    actualCount = list.Count;
        //    Assert.AreEqual(expectedCount, actualCount);

        //    // After Remove
        //    list.Remove();
        //    expectedCount = 0;
        //    actualCount = list.Count;
        //    Assert.AreEqual(expectedCount, actualCount);

        //    // After Insert
        //    list.Add(50);
        //    list.Insert(100, 0);
        //    expectedCount = 2;
        //    actualCount = list.Count;
        //    Assert.AreEqual(expectedCount, actualCount);

        //    // After Remove At
        //    list.RemoveAt(0);
        //    expectedCount = 1;
        //    actualCount = list.Count;
        //    Assert.AreEqual(expectedCount, actualCount);
        //}

        [TestMethod]
        public void DLL_EmptyList()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            int expectedCount = 0;
            int actualCount = list.Count;

            string expectedString = "";
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfOne()
        {
            DoubleLinkedList<int> list = CreateDLLOne();
            int expectedCount = 1;
            string expectedString = "24";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfOne_Remove()
        {
            DoubleLinkedList<int> list = CreateDLLOne();
            int expectedReturn = 24;
            int expectedCount = 0;
            string expectedString = "";

            int actualReturn = list.Remove();
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_Remove()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 24;
            int expectedCount = 9;
            string expectedString = "3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Remove();
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveAll()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            List<int> vals = new List<int>() { 24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42 };
            int expectedReturn = 0;
            int expectedCount = 9;
            string expectedString;

            for (int i = 0; i < 10; i++)
            {
                expectedReturn = vals[0];
                vals.RemoveAt(0);
                expectedCount = vals.Count;
                expectedString = ArrayToString(vals.ToArray());

                int actualReturn = list.Remove();
                int actualCount = list.Count;
                string actualString = list.ToString();

                Assert.AreEqual(expectedReturn, actualReturn);
                Assert.AreEqual(expectedCount, actualCount);
                Assert.AreEqual(expectedString, actualString);
            }
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveThenAdd()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            list.Remove();
            list.Add(404);
            int expectedCount = 10;
            string expectedString = "3, 6, 0, 6, 17, 100, 2014, 122778, 42, 404";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveAt0()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 24;
            int expectedCount = 9;
            string expectedString = "3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.RemoveAt(0);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveAt5()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 17;
            int expectedCount = 9;
            string expectedString = "24, 3, 6, 0, 6, 100, 2014, 122778, 42";

            int actualReturn = list.RemoveAt(5);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveAt9()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 42;
            int expectedCount = 9;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778";

            int actualReturn = list.RemoveAt(9);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void DLL_ListOfTen_RemoveAt10Exception()
        {
            DoubleLinkedList<int> list = CreateDLLTen();

            int actualReturn = list.RemoveAt(10);
        }

        [TestMethod]
        public void DLL_ListOfTen_InsertAt0()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedCount = 11;
            string expectedString = "711, 24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            list.Insert(711, 0);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_InsertAt5()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedCount = 11;
            string expectedString = "24, 3, 6, 0, 6, 711, 17, 100, 2014, 122778, 42";

            list.Insert(711, 5);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_InsertAt9()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedCount = 11;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 711, 42";

            list.Insert(711, 9);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void DLL_ListOfTen_InsertAt10Exception()
        {
            DoubleLinkedList<int> list = CreateDLLTen();

            list.Insert(711, 10);
        }

        [TestMethod]
        public void DLL_ListOfTen_GetAt0()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 24;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Get(0);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_GetAt5()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 17;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Get(5);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_GetAt9()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 42;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Get(9);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void DLL_ListOfTen_GetAt10Exception()
        {
            DoubleLinkedList<int> list = CreateDLLTen();

            list.Get(10);
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueAtHead()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 0;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Search(24);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueAtTail()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 9;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Search(42);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueAppearsTwice()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = 2;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Search(6);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueNotInList()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            int expectedReturn = -1;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Search(999);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueInEmptyList()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            int expectedReturn = -1;
            int expectedCount = 0;
            string expectedString = "";

            int actualReturn = list.Search(24);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DLL_Clear()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
            list.Clear();
            int expectedCount = 0;
            string expectedString = "";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }


    }
}
