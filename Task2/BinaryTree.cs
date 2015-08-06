using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public enum TreeOrder
    {
        Preorder,
        Inorder,
        Postorder
    }

    public class BinaryTree<T>
    {
        private Node<T> root;
        private Comparison<T> comparison; 

        public BinaryTree()
        {
            comparison = Comparer<T>.Default.Compare;
        }

        public BinaryTree(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public BinaryTree(IComparer<T> comparer)
        {
            comparison = comparer.Compare;
        }

        public void Add(T item)
        {
            root = AddNode(root, item);
        }

        public IEnumerable<T> Order(TreeOrder order)
        {
            IEnumerable<T> result = null;
            switch (order)
            {
                case TreeOrder.Preorder:
                    result = PreOrder(root);
                    break;
                case TreeOrder.Inorder:
                    result = InOrder(root);
                    break;
                case TreeOrder.Postorder:
                    result = PostOrder(root);
                    break;
            }
            return result;
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            Queue<T> enumerable = new Queue<T>();
            Stack<Node<T>> stack = new Stack<Node<T>> ();
            while (node != null || stack.Count != 0)
            {
                if (stack.Count > 0)
                {
                    node = stack.Pop();
                }
                while (node != null)
                {
                    enumerable.Enqueue(node.Data);
                    if (node.Right != null) stack.Push(node.Right);
                        node = node.Left;
                }
            }
            return enumerable;
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            Queue<T> enumerable = new Queue<T>();
            Stack<Node<T>> stack = new Stack<Node<T>> (); 
            while (node!=null || stack.Count > 0)
            {
                if (stack.Count > 0)
                {
                    node = stack.Pop();
                    enumerable.Enqueue(node.Data);
                    if (node.Right != null) 
                        node=node.Right;
                    else 
                        node=null;
                }
                while (node!=null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
            return enumerable;
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            Queue<T> enumerable = new Queue<T>();
            Stack<Node<T>> stack = new Stack<Node<T>>();
            while (node != null || stack.Count > 0)
            {
                if (stack.Count > 0)
                {
                    node = stack.Pop();
                    enumerable.Enqueue(node.Data);
                    if (node.Left != null)
                        node = node.Left;
                    else
                        node = null;
                }
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Right;
                }
            }
            return enumerable;


            /*Queue<T> enumerable = new Queue<T>();
            Stack<Node<T>> stack = new Stack<Node<T>> (); 
            while (node!=null || stack.Count > 0)
            {
                if (stack.Count > 0)
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && node.Right == stack.Last())
                    {
                        node = stack.Pop();
                    }
                    else
                    {
                        enumerable.Enqueue(node.Data);
                        node=null;
                    }
                }
                while (node!=null)
                {
                    stack.Push(node);
                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                        stack.Push(node);
                    }
                    node = node.Left;
                }
            }
            return enumerable;*/
        }

        private Node<T> AddNode(Node<T> node, T item)
        {
            if (node == null)
                node = new Node<T>(item);
            else
            {
                if (comparison(item, node.Data) > 0)
                    node.Right = AddNode(node.Right, item);
                else
                    node.Left = AddNode(node.Left, item);
            }
            return node;
        }

        private class Node<N>
        {
            public Node(N data)
            {
                Data = data;
                Left = null;
                Right = null;
            }

            public N Data { get; private set; }
            public Node<N> Left { get; set; }
            public Node<N> Right { get; set; }
        }
    }
}
