using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Test
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void BinaryTreeTest_Add()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(6);
            tree.Add(3);
            tree.Add(9);
            tree.Add(1);
            tree.Add(4);

            int i = 0;
        }

        [TestMethod]
        public void BinaryTreeTest_PreOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            String order = String.Empty;

            tree.Add(6);
            tree.Add(3);
            tree.Add(9);
            tree.Add(1);
            tree.Add(4);

            foreach (var item in tree.Order(TreeOrder.Preorder))
            {
                order += item;
            }

            Assert.AreEqual("63149", order);
        }

        [TestMethod]
        public void BinaryTreeTest_InOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            String order = String.Empty;

            tree.Add(6);
            tree.Add(3);
            tree.Add(9);
            tree.Add(1);
            tree.Add(4);

            foreach (var item in tree.Order(TreeOrder.Inorder))
            {
                order += item;
            }

            Assert.AreEqual("13469", order);
        }

        [TestMethod]
        public void BinaryTreeTest_PostOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            String order = String.Empty;

            tree.Add(6);
            tree.Add(3);
            tree.Add(9);
            tree.Add(1);
            tree.Add(4);

            foreach (var item in tree.Order(TreeOrder.Postorder))
            {
                order += item;
            }

            Assert.AreEqual("96431", order);
        }
    }
}
