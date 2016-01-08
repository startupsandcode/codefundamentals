﻿using System;
using System.Collections.Generic;
using System.Text;
namespace TreeSort
{
    class Node
    {
        public int item;
        public Node leftc;
        public Node rightc;
        public override string ToString()
        {
            return "{" + item + "}";
        }

        public void display()
        {
            Console.Write("[");
            Console.Write(item);
            Console.Write("]");
        }
    }
    class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }
        public Node ReturnRoot()
        {
            return root;
        }
        public void Insert(int id)
        {
            Node newNode = new Node();
            newNode.item = id;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (id < current.item)
                    {
                        current = current.leftc;
                        if (current == null)
                        {
                            parent.leftc = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightc;
                        if (current == null)
                        {
                            parent.rightc = newNode;
                            return;
                        }
                    }
                }
            }
        }
        public void Preorder(Node Root)
        {
            if (Root != null)
            {
                Root.display();
                Preorder(Root.leftc);
                Preorder(Root.rightc);
            }
        }
        public void Inorder(Node Root)
        {
            if (Root != null)
            {
                Inorder(Root.leftc);
                Root.display();
                Inorder(Root.rightc);
            }
        }
        public void Postorder(Node Root)
        {
            if (Root != null)
            {
                Postorder(Root.leftc);
                Postorder(Root.rightc);
                Root.display();
            }
        }
        
        public void print(Node root)
        {
            print("", true, root);
        }

        private void print(String prefix, bool isTail, Node curNode)
        {
            if (curNode == null)
            {
                return;
            }
            //for (int i = 0; i < children.Count() - 1; i++)
            //{
            //    children[i].print(prefix + (isTail ? "    " : "│   "), false);
            //}
            //if (children.Count() > 0)
            //{
            //    children[children.Count() - 1].print(prefix + (isTail ? "    " : "│   "), true);
            //}
            print(prefix + (isTail ? "    " : "│   "), curNode.leftc == null, curNode.leftc);
            Console.WriteLine(prefix + (isTail ? "   " : "├── ") + curNode.ToString());
            print(prefix + (isTail ? "    " : "│   "), curNode.rightc == null, curNode.rightc); 
            
            
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Tree theTree = new Tree();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 20; i++)
            {
                theTree.Insert(r.Next(1,100));
            }
            //theTree.Insert(20);
            //theTree.Insert(25);
            //theTree.Insert(45);
            //theTree.Insert(15);
            //theTree.Insert(67);
            //theTree.Insert(43);
            //theTree.Insert(80);
            //theTree.Insert(33);
            //theTree.Insert(67);
            //theTree.Insert(99);
            //theTree.Insert(91);
            Console.WriteLine("Inorder Traversal : ");
            theTree.Inorder(theTree.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Preorder Traversal : ");
            theTree.Preorder(theTree.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Postorder Traversal : ");
            theTree.Postorder(theTree.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            theTree.print(theTree.ReturnRoot());
            Console.WriteLine(" ");
            Console.ReadLine();
        }
    }
}
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class BinaryTree
    {
        static void Main(string[] args)
        {
            List<TreeNode> tn = new List<TreeNode>();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 100; i++)
			{
                InsertNode(r.Next);			 
			}
            for (int i = 0; i < tn.Count(); i++)
            {
                tn[i].print();
            }
            Console.ReadLine();
        }

        public class TreeNode
        {
            public int data;
            public List<TreeNode> children;

            public TreeNode(int data, List<TreeNode> children)
            {
                this.data = data;
                this.children = children;
            }

            public void InsertNode(int data)
            {
                if (this.data == null){
                    this.data = data;
                    this.children = new List<TreeNode>();
                }
            }

            public void print()
            {
                print("", true);
            }

            private void print(String prefix, bool isTail) {
                Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + data.ToString());
                for (int i = 0; i < children.Count() - 1; i++) {
                    children[i].print(prefix + (isTail ? "    " : "│   "), false);
                }
                if (children.Count() > 0) {
                    children[children.Count() - 1].print(prefix + (isTail ?"    " : "│   "), true);
                }
            }
        }
    }
}*/
