using System;
using System.Collections.Generic;
using System.Linq;

namespace ЛР6
{
    public class Graph
    {
        public int VertexCount;
        public int EdgeCount { get; set; }
        public int[,] AdjcencyMatrix { get; set; }
        public Dictionary<int, List<Dictionary<int, int>>> AdjcencyList { get; set; }
        public int[,] IncidenceMatrix { get; set; }
        public List<List<int>> EdgeList { get; set; }

        public Graph(int vertexCount)
        {
            VertexCount = vertexCount;
        }

        public Graph(Graph source)
        {
            VertexCount = source.VertexCount;
            EdgeCount = source.EdgeCount;
            AdjcencyList = source.AdjcencyList;
            AdjcencyMatrix = source.AdjcencyMatrix;
            IncidenceMatrix = source.IncidenceMatrix;
        }
        ~Graph()
        {
            Console.WriteLine("Goodbye");
        }

        public void AddAdjcencyMatrixEdge(int v1, int v2, int weight = 1)
        {
            if (AdjcencyMatrix is null)
            {
                AdjcencyMatrix = new int[VertexCount, VertexCount];

                for (var i = 0; i < VertexCount; i++)
                {
                    for (var j = 0; j < VertexCount; j++)
                    {
                        AdjcencyMatrix[i, j] = 0;
                    }
                }
            }

            AdjcencyMatrix[v1, v2] = weight;
        }

        public void AddAdjcencyListEdge(int v1, int v2, int weight = 1)
        {
            if (AdjcencyList is null)
            {
                AdjcencyList = new Dictionary<int, List<Dictionary<int, int>>>();
            }

            if (AdjcencyList.ContainsKey(v1))
            {
                AdjcencyList.GetValueOrDefault(v1).Add(new Dictionary<int, int> { { v2, weight } });
            }
            else
            {
                AdjcencyList.Add(v1, new List<Dictionary<int, int>> { new Dictionary<int, int> { { v2, weight } } });
            }

            if (AdjcencyList.ContainsKey(v2))
            {
                AdjcencyList.GetValueOrDefault(v2).Add(new Dictionary<int, int> { { v1, weight } });
            }
            else
            {
                AdjcencyList.Add(v2, new List<Dictionary<int, int>> { new Dictionary<int, int> { { v1, weight } } });
            }
        }

        public void AddIncidenceMatrixEdge(int v1, int v2, int weight = 1)
        {
            if (IncidenceMatrix is null)
            {
                IncidenceMatrix = new int[VertexCount, EdgeCount];
                for (var i = 0; i < EdgeCount; i++)
                {
                    for (var j = 0; j < VertexCount; j++)
                    {
                        IncidenceMatrix[i, j] = 0;
                    }
                }
            }

            var emptyRowNumber = 0;
            for (var i = 0; i < VertexCount; i++)
            {
                var isEmptyRow = true;
                for (var j = 0; j < EdgeCount; j++)
                {
                    if (IncidenceMatrix[i, j] != 0)
                    {
                        isEmptyRow = false;
                        break;
                    }
                }

                if (isEmptyRow)
                {
                    emptyRowNumber = i;
                    break;
                }
            }

            if (IncidenceMatrix.Length < (emptyRowNumber + 1) * VertexCount)
            {
                new int[VertexCount].CopyTo(IncidenceMatrix, emptyRowNumber);
            }

            IncidenceMatrix[v1, emptyRowNumber] = weight;
            IncidenceMatrix[v2, emptyRowNumber] = weight;
        }

        public void AddEdgeListEdge(int v1, int v2, int weight = 1)
        {
            if (EdgeList is null)
            {
                EdgeList = new List<List<int>>();
            }

            if (EdgeList.Any(x => x[0] == v1 && x[1] == v2)
                || EdgeList.Any(x => x[0] == v2 && x[1] == v1))
            {
                return;
            }

            EdgeList.Add(new List<int> { v1, v2 });
        }

        public void Print()
        {
            for (var i = 0; i < VertexCount; i++)
            {
                for (var j = 0; j < VertexCount; j++)
                {
                    Console.Write($" {AdjcencyMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void RemoveAdjcencyMatrixEdge(int v1, int v2)
        {
            if (AdjcencyMatrix is null)
            {
                return;
            }

            AdjcencyMatrix[v1, v2] = 0;
        }

        public void RemoveAdjcencyMatrixVertex(int v1)
        {
            if (v1 > VertexCount)
            {
                return;
            }
            else
            {
                int i;

                while (v1 < VertexCount)
                {
                    for (i = 0; i < VertexCount; ++i)
                    {
                        AdjcencyMatrix[i, v1] = AdjcencyMatrix[i, v1 + 1];
                    }

                    for (i = 0; i < VertexCount; ++i)
                    {
                        AdjcencyMatrix[v1, i] = AdjcencyMatrix[v1 + 1, i];
                    }
                    v1++;
                }

                VertexCount--;
            }
        } 

        //расширение
        public Dictionary<Deep, List<Deep>> DeepList { get; set; }

        public void DS(int i)
        {
            var vertex = DeepList.ElementAt(i).Key;

            if (vertex.VertexState == State.Visited)
            {
                return;
            }

            if (vertex.VertexState != State.Visited)
            {
                vertex.VertexState = State.Visited;
                Console.Write($" {i}={vertex.Weight} ");
            }
            DeepList.ElementAt(i).Value.ForEach(v => DS(v.Weight));

        }
    }
}