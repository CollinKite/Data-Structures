using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures.BST;

namespace MyUnitTests
{
    public class MyBSTTests
    {
        [TestMethod]
        public void BSTAddTest()
        {
            BinarySearchTree<int> bst = new();
            bst.Add(4);
            int ExpectedCount = 1;
            string ExpectedInOrder = "4";

            int ActualCount = bst.Count;
            string ActualInOrder = bst.InOrder();

            Assert.AreEqual(ExpectedCount, ActualCount);
            Assert.AreEqual(ExpectedInOrder, ActualInOrder);

        }

        [TestMethod]
        public void BSTAddFiveTest()
        {
            BinarySearchTree<int> bst = new();
            bst.Add(50);
            bst.Add(2);
            bst.Add(68);
            bst.Add(14);
            bst.Add(33);
            int ExpectedCount = 5;
            string ExpectedInOrder = "2, 14, 33, 50, 68";

            int ActualCount = bst.Count;
            string ActualInOrder = bst.InOrder();

            Assert.AreEqual(ExpectedCount, ActualCount);
            Assert.AreEqual(ExpectedInOrder, ActualInOrder);

        }

        [TestMethod]
        public void BSTClearTest()
        {
            BinarySearchTree<int> bst= new();
            bst.Add(2);
            bst.Add(5);
            bst.Add(20);

            bst.Clear();

            int ExpectedCount = 0;
            string ExpectedInOrder = "";

            int ActualCount = bst.Count;
            string ActualInOrder = bst.InOrder();

            Assert.AreEqual(ExpectedCount, ActualCount);
            Assert.AreEqual(ExpectedInOrder, ActualInOrder);

        }
    }
}
