using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ЛР5
{
    class Program
    {
        static void Main(string[] args)
        {
           var n = 200;
            var binaryTree = new BinaryTree();
            var rand = new Random();
            var stopwatch = new Stopwatch();

            var distinctValues = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int value;
                do
                {
                    value = rand.Next(0, 200);
                } 
                while (distinctValues.Contains(value));
                distinctValues.Add(value);
            }

            distinctValues.ForEach(x => binaryTree.Add(x));
            binaryTree.PrintTree();

            stopwatch.Start();

            var result = binaryTree.Search(33);

            stopwatch.Stop();
            Console.WriteLine("Элемент: " + (result != null ? "<" +  result?.Data.ToString()  + "> найден за " + stopwatch.ElapsedMilliseconds + "ms"  : "не найден"));
            stopwatch.Restart();
            var infixList = binaryTree.Preorder();
            stopwatch.Stop();
            Console.WriteLine(string.Join(" | ", infixList) + " за " + stopwatch.ElapsedMilliseconds + " ms ");
            Console.WriteLine("\n B+");

            var tree = new BPlusTree { Degree = 5 };
            tree.Create(distinctValues);
            tree.PrintTree();

            stopwatch.Restart();
            var resultBPlus = tree.Search(33);

            stopwatch.Stop();
            Console.WriteLine("Элемент: " + (resultBPlus != null ? "<" +  string.Join(", ", resultBPlus) + "> найден за " + stopwatch.ElapsedMilliseconds + "ms"  : "не найден"));

            stopwatch.Restart();
            var preorderList = tree.Preorder();
            stopwatch.Stop();
            Console.WriteLine(string.Join(" | ", preorderList) + " за " + stopwatch.ElapsedMilliseconds + " ms ");

        }
    }    

}
