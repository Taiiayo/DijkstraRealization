using System;

namespace MyDijkstraRealization
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = {
                { 0, 10, 30, 50, 10 },
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 10,},
                { 0, 40, 20, 0, 0},
                { 10, 0, 10, 30, 0},                
            };

            FulfilDijkstraLogic(graph, 0, 5);
        }

        private static int MinimumEdgeDistance(int[] edgeDistance, bool[] shortestPathsTreeWasSet, int numberOfVertices)
        {
            int minEdgeDistanceValue = int.MaxValue;
            int minEdgeDistanceIndex = 0;

            for (int vertex = 0; vertex < numberOfVertices; ++vertex)
            {
                if (shortestPathsTreeWasSet[vertex] == false && edgeDistance[vertex] <= minEdgeDistanceValue)
                {
                    minEdgeDistanceValue = edgeDistance[vertex];
                    minEdgeDistanceIndex = vertex;
                }
            }

            return minEdgeDistanceIndex;
        }

        private static void PrintResults(int[] edgeDistance, int numberOfVertices)
        {
            Console.WriteLine("Vertex    Distance from root");

            for (int i = 0; i < numberOfVertices; ++i)
            {
                Console.WriteLine("{0}\t  {1}", i, edgeDistance[i]);              
            }
            Console.ReadLine();
        }

        public static void FulfilDijkstraLogic(int[,] graph, int root, int numberOfVertices)
        {
            int[] edgeDistance = new int[numberOfVertices];
            bool[] shortestPathsTreeWasSet = new bool[numberOfVertices];

            for (int i = 0; i < numberOfVertices; ++i)
            {
                edgeDistance[i] = int.MaxValue;
                shortestPathsTreeWasSet[i] = false;
            }

            edgeDistance[root] = 0;

            for (int count = 0; count < numberOfVertices - 1; ++count)
            {
                int minEdgeDistanceIndex = MinimumEdgeDistance(edgeDistance, shortestPathsTreeWasSet, numberOfVertices);
                shortestPathsTreeWasSet[minEdgeDistanceIndex] = true;

                for (int vertex = 0; vertex < numberOfVertices; ++vertex)
                {
                    if (!shortestPathsTreeWasSet[vertex] &&
                        Convert.ToBoolean(graph[minEdgeDistanceIndex, vertex]) &&
                        edgeDistance[minEdgeDistanceIndex] != int.MaxValue &&
                        edgeDistance[minEdgeDistanceIndex] + graph[minEdgeDistanceIndex, vertex] < edgeDistance[vertex])
                    {
                        edgeDistance[vertex] = edgeDistance[minEdgeDistanceIndex] + graph[minEdgeDistanceIndex, vertex];
                    }
                        
                }
            }

            PrintResults(edgeDistance, numberOfVertices);
        }
    }
}
