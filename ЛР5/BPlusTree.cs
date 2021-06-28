using System;
using System.Collections.Generic;
using System.Linq;

namespace ЛР5
{
    public class BPlusTree
    {
        public int Degree { get; set; }
        public BPlusTreeNode RootNode { get; set; }

        public void Create(List<int> values)
        {
            values.Sort();
            var delimiter = Degree;
            var data = new List<int>(values);
            var levels = new List<List<List<int>>>();

            do
            {
                var times = (data.Count / delimiter) + 1;
                var nextLevel = new List<int>();
                var nextLevelLists = new List<List<int>>();
                var skip = delimiter == Degree ? delimiter : delimiter - 1;
                for (var i = 0; i < times; i++)
                {
                    nextLevelLists.Add(data.Skip(i * skip).Take(skip).ToList());
                }

                var max = delimiter == Degree ? delimiter - 1 : (Degree / 2);
                nextLevelLists.ForEach(x =>
                {
                    if (x.Count > max)
                    {
                        nextLevel.Add(x[max]);
                        x.RemoveAt(max);
                    }
                });

                levels.Add(nextLevelLists);
                delimiter--;
                data = nextLevel;
            } while (data.Count > 0);

            RootNode = SeedTree(levels, null, levels.Count - 1, 0);

        }

        public BPlusTreeNode SeedTree(List<List<List<int>>> levels, BPlusTreeNode parent, int level, int num)
        {
            var node = new BPlusTreeNode(levels[level][num]);
            node.ParentNode = parent ?? RootNode;
            if (level - 1 < 0)
            {
                return node;
            }

            var childCount = levels[level - 1].Count / levels[level].Count + 1;
            node.ChildrenNodes = levels[level - 1]
                .Skip(num * childCount)
                .Take(childCount)
                .Select((x, i) => SeedTree(levels, node, level - 1, i + num * childCount))
                .ToList();

            return node;
        }

        public void PrintTree()
        {
            PrintTree(RootNode);
        }

        private void PrintTree(BPlusTreeNode startNode, string indent = "")
        {
            if (startNode != null)
            {
                Console.WriteLine($"{indent} : {string.Join("-", startNode.Data)}");
                indent += new string(' ', 3);
                startNode.ChildrenNodes?.ForEach(x => PrintTree(x, indent));
            }
        }

        public BPlusTreeNode Search(int searchField, BPlusTreeNode currentNode = null)
        {
            currentNode = currentNode ?? RootNode;

            if (currentNode.Data != null && currentNode.Data.Contains(searchField))
            {
                return currentNode;
            }

            currentNode = currentNode.ChildrenNodes?.FirstOrDefault(x => searchField > x.Data.First() && searchField < x.Data.LastOrDefault());

            if (currentNode is null)
            {
                return null;
            }

            return Search(searchField, currentNode);
        }

        public List<int> Preorder(BPlusTreeNode startNode = null, List<int> result = null)
        {
            result = result ?? new List<int>();

            startNode = startNode ?? RootNode;

            if (startNode != null)
            {
                result.AddRange(startNode.Data);
                startNode.ChildrenNodes?.ForEach(x => Preorder(x, result));
            }

            return result;
        }

    }
}