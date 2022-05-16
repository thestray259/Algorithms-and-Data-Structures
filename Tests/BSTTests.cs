using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgoDataStructures; 

namespace CSharpBstTester
{
    [TestClass]
    public class BSTTests
    {
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
        public void AddOneValueToEmptyTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expected = "10";
            int expectedCount = 1;

            bst.Add(10);

            string actual = bst.InOrder();
            int actualCount = bst.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesToTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expected = "10, 24, 1337";
            int expectedCount = 3;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);

            string actual = bst.InOrder();
            int actualCount = bst.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddManyValuesToEmptyTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expectedInOrder = "7, 8, 9, 10, 11, 12, 13, 24, 90, 100, 110, 1337, 1350, 1400, 1500";
            int[] expectedArray = new int[] { 7, 8, 9, 10, 11, 12, 13, 24, 90, 100, 110, 1337, 1350, 1400, 1500 };

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            int[] actualArray = bst.ToArray();

            Assert.AreEqual(15, bst.Count);
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(actualArray));
            Assert.AreEqual(expectedInOrder, bst.InOrder());
        }

        [TestMethod]
        public void AddManyValuesWithDuplicate()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expectedInOrder = "7, 8, 9, 10, 11, 12, 13, 24, 24, 90, 100, 110, 1337, 1350, 1400, 1500";
            int[] expectedArray = new int[] { 7, 8, 9, 10, 11, 12, 13, 24, 24, 90, 100, 110, 1337, 1350, 1400, 1500 };

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);
            bst.Add(24);

            int[] actualArray = bst.ToArray();

            Assert.AreEqual(16, bst.Count);
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(actualArray));
            Assert.AreEqual(expectedInOrder, bst.InOrder());
        }

        [TestMethod]
        public void ClearisCorrect()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            bst.Clear();
            string actualInorder = bst.InOrder();

            Assert.AreEqual(0, bst.Count);
            Assert.IsTrue(string.IsNullOrEmpty(actualInorder));
        }

        [TestMethod]
        public void ContainsRoot()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            Assert.IsTrue(bst.Contains(24));
        }

        [TestMethod]
        public void ContainsMax()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            Assert.IsTrue(bst.Contains(1500));
        }

        [TestMethod]
        public void ContainsMin()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            Assert.IsTrue(bst.Contains(7));
        }

        [TestMethod]
        public void ContainsMissingValue()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            Assert.IsFalse(bst.Contains(42));
        }

        [TestMethod]
        public void RemoveLeftLeaf()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expectedInOrder = "24, 1337";
            int[] expectedArray = new int[] { 24, 1337 };

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);

            bst.Remove(10);

            Assert.AreEqual(2, bst.Count);
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(bst.ToArray()));
            Assert.AreEqual(expectedInOrder, bst.InOrder());
        }

        [TestMethod]
        public void RemoveRightLeaf()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expectedInOrder = "10, 24";
            int[] expectedArray = new int[] { 10, 24 };

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);

            bst.Remove(1337);

            Assert.AreEqual(2, bst.Count);
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(bst.ToArray()));
            Assert.AreEqual(expectedInOrder, bst.InOrder());
        }

        [TestMethod]
        public void RemoveRoot()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expected = "10, 1337";
            int[] expectedArray = new int[] { 10, 1337 };
            int expectedCount = 2;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);

            bst.Remove(24);

            string actual = bst.InOrder();
            int actualCount = bst.Count;
            int[] actualArray = bst.ToArray();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(actualArray));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveLeftBranchRoot()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int[] expectedArray = new int[] { 7, 8, 9, 11, 12, 13, 24, 90, 100, 110, 1337, 1350, 1400, 1500 };
            int expectedCount = expectedArray.Length;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            bst.Remove(10);

            int actualCount = bst.Count;
            int[] actualArray = bst.ToArray();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(bst.ToArray()));
        }

        [TestMethod]
        public void RemoveRightBranchRoot()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int[] expectedArray = new int[] { 7, 8, 9, 10, 11, 12, 13, 24, 90, 100, 110, 1350, 1400, 1500 };
            int expectedCount = expectedArray.Length;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            bst.Remove(1337);

            int actualCount = bst.Count;
            int[] actualArray = bst.ToArray();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(bst.ToArray()));
        }

        [TestMethod]
        public void RemoveRootFromLargeTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int[] expectedArray = new int[] { 7, 8, 9, 10, 11, 12, 13, 90, 100, 110, 1337, 1350, 1400, 1500 };
            int expectedCount = expectedArray.Length;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            bst.Remove(24);

            int actualCount = bst.Count;
            int[] actualArray = bst.ToArray();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(bst.ToArray()));
        }

        [TestMethod]
        public void RemoveDuplicateValueFromLargeTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int[] expectedArray = new int[] { 7, 8, 9, 10, 11, 12, 13, 24, 90, 100, 110, 1337, 1350, 1400, 1500 };
            int expectedCount = expectedArray.Length;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);
            bst.Add(24);

            bst.Remove(24);

            int actualCount = bst.Count;
            int[] actualArray = bst.ToArray();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(actualArray));
        }

        [TestMethod]
        public void CountIsCorrectAfterAdd()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 15;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            Assert.AreEqual(expected, bst.Count);
        }

        [TestMethod]
        public void CountIsCorrectAfterRemove()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 14;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            bst.Remove(10);

            Assert.AreEqual(expected, bst.Count);
        }

        [TestMethod]
        public void CountIsCorrectAfterAddRemoveAdd()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 13;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            bst.Remove(10);
            bst.Remove(1337);
            bst.Remove(24);

            bst.Add(1842);

            Assert.AreEqual(expected, bst.Count);
        }

        [TestMethod]
        public void OrderedStringInorderIsCorrect()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expectedInOrder = "7, 8, 9, 10, 11, 12, 13, 24, 90, 100, 110, 1337, 1350, 1400, 1500";

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            var actual = bst.InOrder();
            Assert.AreEqual(expectedInOrder, actual);
        }

        [TestMethod]
        public void OrderedStringPreorderIsCorrect()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expectedInOrder = "24, 10, 8, 7, 9, 12, 11, 13, 1337, 100, 90, 110, 1400, 1350, 1500";

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            Assert.AreEqual(expectedInOrder, bst.PreOrder());
        }

        [TestMethod]
        public void OrderedStringPostorderIsCorrect()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expectedInOrder = "7, 9, 8, 11, 13, 12, 10, 90, 110, 100, 1350, 1500, 1400, 1337, 24";

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            Assert.AreEqual(expectedInOrder, bst.PostOrder());
        }

        [TestMethod]
        public void HeightOfTheEmptyTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 0;
            int actual = bst.Height();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HeightOfTheSimpleTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 1;

            bst.Add(24);

            int actual = bst.Height();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HeightOfLargeTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 4;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            int actual = bst.Height();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HeightOfWorstCaseLeftTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 15;

            bst.Add(7);
            bst.Add(8);
            bst.Add(9);
            bst.Add(10);
            bst.Add(11);
            bst.Add(12);
            bst.Add(13);
            bst.Add(24);
            bst.Add(90);
            bst.Add(100);
            bst.Add(110);
            bst.Add(1337);
            bst.Add(1350);
            bst.Add(1400);
            bst.Add(1500);

            int actual = bst.Height();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HeightOfWorstCaseRightTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 15;

            bst.Add(1500);
            bst.Add(1400);
            bst.Add(1350);
            bst.Add(1337);
            bst.Add(110);
            bst.Add(100);
            bst.Add(90);
            bst.Add(24);
            bst.Add(13);
            bst.Add(12);
            bst.Add(11);
            bst.Add(10);
            bst.Add(9);
            bst.Add(8);
            bst.Add(7);

            int actual = bst.Height();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToArrayOutputIsCorrect()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int[] expectedArr = { 7, 8, 9, 10, 11, 12, 13, 24, 90, 100, 110, 1337, 1350, 1400, 1500 };

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            Assert.AreEqual(ArrayToString(expectedArr), ArrayToString(bst.ToArray()));
        }

        [TestMethod]
        public void RemoveRightRoot()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 8;

            bst.Add(5);
            bst.Add(2);
            bst.Add(12);
            bst.Add(1);
            bst.Add(3);
            bst.Add(9);
            bst.Add(21);
            bst.Add(19);
            bst.Add(25);

            bst.Remove(12);

            Assert.AreEqual(expected, bst.Count);
        }

        private bool SequencesAreEqual<T>(IEnumerable<T> col1, IEnumerable<T> col2) where T : IComparable<T>
        {
            bool colsAreEqual = false;

            if (col1 != null && col2 != null)
            {
                List<T> l1 = col1.ToList();
                List<T> l2 = col2.ToList();
                colsAreEqual = l1.Count == l2.Count;

                if (colsAreEqual)
                {
                    for (int i = 0; i < l1.Count && colsAreEqual; i++)
                    {
                        colsAreEqual = l1[i].CompareTo(l2[i]) == 0;
                    }
                }
            }

            return colsAreEqual;
        }
		
		[TestMethod]
        public void BSTRemoveNodeWithTwoChildrenWhereChildHasDuplicates()
        {
			//This tests is written to make sure count works properly
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(10);
            bst.Add(4);
            bst.Add(12);
            bst.Add(11);
            bst.Add(11);
            bst.Add(11);
            bst.Add(18);

			Assert.AreEqual("4, 10, 11, 11, 11, 12, 18", bst.InOrder());
            bst.Remove(11);
			
            Assert.AreEqual("4, 10, 11, 11, 12, 18", bst.InOrder());
			//Left, find highest
            Assert.AreEqual("10, 4, 12, 11, 11, 18", bst.PreOrder());
            Assert.AreEqual("4, 11, 11, 18, 12, 10", bst.PostOrder());
			//Right, find lowest 
			//Assert.AreEqual("10, 4, 12, 11, 11, 18", bst.PreOrder());
            //Assert.AreEqual("4, 11, 11, 18, 12, 10", bst.PostOrder());
			

            bst.Remove(12);
            Assert.AreEqual("4, 10, 11, 11, 18", bst.InOrder());
			//Left, find highest
            Assert.AreEqual("10, 4, 11, 11, 18", bst.PreOrder());
			Assert.AreEqual("4, 18, 11, 11, 10", bst.PostOrder());
			//Right, find lowest N, L, R | L, R, N
            //Assert.AreEqual("10, 4, 18, 11, 11", bst.PreOrder());
			//Assert.AreEqual("4, 11, 11, 18, 10", bst.PostOrder());
        }
    }
}
