using System;
using System.Collections.Generic;
using System.Linq;

namespace ЛР6
{
    class Program
    {
        static void Main(string[] args)
        {
            var vertexCount = 5;
            var random = new Random();

            Graph graph = new Graph(vertexCount);
            for (var i = 0; i < vertexCount; i++)
            {
                for (var j = 0; j < vertexCount; j++)
                {
                    if (i != j)
                    {
                        graph.AddAdjcencyMatrixEdge(i, j, random.Next(9));
                    }
                }
            }
            
            Console.WriteLine("Матрицa смежности (гл.диагональ = 0)");
            graph.Print();

            

            //расширение
        //     graph.DeepList = new Dictionary<Deep, List<Deep>>();

        //     for (var i = 0; i < vertexCount; i++)
        //     {
        //         var randomWeights = new List<Deep>();

        //         randomWeights.Add(new Deep
        //         {
        //             Weight = random.Next(0, 9),
        //             VertexState = State.NotVisited
        //         });

        //         graph.DeepList.Add(new Deep { Weight = i, VertexState = State.NotVisited }, randomWeights);
        //     }
        //     try
        //     {
        //          while (graph.DeepList.Keys.Any(x => x.VertexState == State.NotVisited))
        //         {
        //             var t = graph.DeepList.Keys.First(x => x.VertexState == State.NotVisited);
        //             graph.DS(t.Weight);
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine("\nОшИбКа " + ex);
        //     }

         }


    }
}
