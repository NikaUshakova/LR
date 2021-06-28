using System;
using System.Collections.Generic;

namespace ЛР5
{
    public class BinaryTree
    {
        public BinaryTreeNode RootNode {get; set;}

        public BinaryTreeNode Add(BinaryTreeNode node, BinaryTreeNode currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);

        }
        public BinaryTreeNode Add(int data)
        {
            return Add(new BinaryTreeNode(data));
        }
        public void PrintTree()
        {
            PrintTree(RootNode);
        }
        private void PrintTree(BinaryTreeNode startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);
                
                PrintTree(startNode.LeftNode, indent, Side.left); //рекурсивный вызов для левой ветки
                PrintTree(startNode.RightNode, indent, Side.right); //рекурсивный вызов для правой ветки
            }
        }

        public BinaryTreeNode Search(int searchField, BinaryTreeNode currentNode = null)
        {
            currentNode = currentNode ?? RootNode;

            if (searchField == currentNode.Data)
            {
                return currentNode;
            }

            currentNode = searchField > currentNode.Data ? currentNode.RightNode : currentNode.LeftNode;

            if (currentNode is null)
            {
                return null;
            }

            return Search(searchField, currentNode);
        }

        public List<int> Preorder()
        {
            var result = new List<int>();

            if (RootNode == null)
            {
                return null;
            }

            var stack = new Stack<BinaryTreeNode>();
            stack.Push(RootNode);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.Data);

                if (node.RightNode != null)
                {
                    stack.Push(node.RightNode);
                }

                if (node.LeftNode != null)
                {
                    stack.Push(node.LeftNode);
                }
            }

            return result;
        }
    }
}