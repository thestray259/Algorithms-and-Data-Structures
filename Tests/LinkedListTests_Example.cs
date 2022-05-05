using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures;
using System.Text;
using System.Collections.Generic;

namespace LinkedListTester
{
    [TestClass]
    public class LinkedListTests
    {
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
            DoubleLinkedList<int> sll = new DoubleLinkedList<int>();
            sll.Add(24);

            return sll;
        }

        private DoubleLinkedList<int> CreateDLLTen()
        {
            DoubleLinkedList<int> sll = new DoubleLinkedList<int>();
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

        [TestMethod]
        public void SLL_EmptyList()
        {
            throw new NotImplementedException();
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
            string expectedString = "";

            // actuals 
            int actualCount = list.Count;
            string actualString = list.ToString();

            // asserts 
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString); 
        }

        [TestMethod]
        public void SLL_ListOfOne_Remove()
        {
            SingleLinkedList<int> list = CreateSLLOne();

            int expectedCount = 0;
            int expectedReturn = 24;
            string expectedString = "";

            int actualCount = list.Count;
            int actualReturn = list.Remove();
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount); 
            Assert.AreEqual(expectedReturn, actualReturn); 
            Assert.AreEqual(expectedString, actualString); 
        }

        [TestMethod]
        public void SLL_ListOfTen_Remove()
        {
            SingleLinkedList<int> list = CreateSLLTen();

            int expectedCount = 9;
            int expectedReturn = 24;
            string expectedString = "3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualCount = list.Count;
            int actualReturn = list.Remove();
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedString, actualString); 
        }

        [TestMethod]
        public void SLL_ListOfTen_RemoveAll()
        {
            SingleLinkedList<int> list = CreateSLLTen();

            int expectedReturn = 42;
            int expectedCount = 0;
            string expectedString = "";
            int actualReturn = 0; 

            for (int i = 0; i < 10; i++)
            {
                actualReturn = (int)list.Remove(); 
            }

            int actualCount = list.Count; 
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_RemoveThenAdd()
        {
            SingleLinkedList<int> list = CreateSLLTen();

            int expectedCount = 10;
            string expectedString = "3, 6, 0, 6, 17, 100, 2014, 122778, 42, 2";

            list.Remove();
            list.Add(2);

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
            string expectedString = "3, 6, 0, 6, 17, 100, 2014, 122778, 42, 2";

            int actualReturn = (int)list.RemoveAt(0);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_RemoveAt5()
        {
            SingleLinkedList<int> list = CreateSLLTen();

            int expectedReturn = 17;
            int expectedCount = 9;
            string expectedString = "24, 3, 6, 0, 6, 100, 2014, 122778, 42, 2";

            int actualReturn = (int)list.RemoveAt(5);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_RemoveAt9()
        {
            SingleLinkedList<int> list = CreateSLLTen();

            int expectedReturn = 42;
            int expectedCount = 9;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 2";

            int actualReturn = (int)list.RemoveAt(9);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void SLL_ListOfTen_RemoveAt10Exception()
        {
            SingleLinkedList<int> list = CreateSLLTen();

            int expectedReturn = 2;
            int expectedCount = 9;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = (int)list.RemoveAt(10);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SLL_ListOfTen_InsertAt0()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_InsertAt5()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_InsertAt9()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void SLL_ListOfTen_InsertAt10Exception()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_GetAt0()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_GetAt5()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_GetAt9()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void SLL_ListOfTen_GetAt10Exception()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueAtHead()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueAtTail()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueAppearsTwice()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueNotInList()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_ListOfTen_SearchForValueInEmptyList()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SLL_Clear()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_EmptyList()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfOne()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfOne_Remove()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_Remove()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveAll()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveThenAdd()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveAt0()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveAt5()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_RemoveAt9()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void DLL_ListOfTen_RemoveAt10Exception()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_InsertAt0()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_InsertAt5()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_InsertAt9()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void DLL_ListOfTen_InsertAt10Exception()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_GetAt0()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_GetAt5()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_GetAt9()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Out-of-bounds index was allowed")]
        public void DLL_ListOfTen_GetAt10Exception()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueAtHead()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueAtTail()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueAppearsTwice()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueNotInList()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_ListOfTen_SearchForValueInEmptyList()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DLL_Clear()
        {
            throw new NotImplementedException();
        }
    }
}
