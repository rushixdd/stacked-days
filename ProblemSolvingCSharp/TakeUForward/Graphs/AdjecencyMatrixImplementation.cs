namespace ProblemSolvingCSharp.TakeUForward.Graphs
{
    [TestClass]
    public class AdjecencyMatrixImplementation
    {
        [TestMethod]
        public void TestAdjacencyMatrix()
        {
            Graph g = new Graph(5);
            g.AddEdge(0, 3);
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(3, 4);
            g.PrintAdjMatrix();
            CollectionAssert.AreEqual(new List<int> { 1, 3 }, g.GetNeighbors(0));
            CollectionAssert.AreEqual(new List<int> { 0, 2 }, g.GetNeighbors(1));
            CollectionAssert.AreEqual(new List<int> { 1 }, g.GetNeighbors(2));
            CollectionAssert.AreEqual(new List<int> { 0, 4 }, g.GetNeighbors(3));
            CollectionAssert.AreEqual(new List<int> { 3 }, g.GetNeighbors(4));
        }

        class Graph
        {
            List<List<int>> adjMatrix;

            internal Graph(int vertices)
            {
                adjMatrix = new List<List<int>>(vertices);
                for (int i = 0; i < vertices; i++)
                {
                    adjMatrix.Add(new List<int>(new int[vertices]));
                }
            }

            public void AddEdge(int src, int dest)
            {
                adjMatrix[src][dest] = 1;
                adjMatrix[dest][src] = 1;
            }

            public void RemoveEdge(int src, int dest)
            {
                adjMatrix[src][dest] = 0;
                adjMatrix[dest][src] = 0;
            }

            public List<int> GetNeighbors(int vertex)
            {
                if (vertex < 0 || vertex >= adjMatrix.Count)
                {
                    throw new ArgumentOutOfRangeException("Vertex out of range ", nameof(vertex));
                }
                List<int> neighbors = new List<int>();
                for (int i = 0; i < adjMatrix[vertex].Count; i++)
                {
                    if (adjMatrix[vertex][i] == 1)
                    {
                        neighbors.Add(i);
                    }
                }
                return neighbors;
            }

            public void PrintAdjMatrix()
            {
                for(int i=0;i<adjMatrix.Count;i++)
                {
                    Console.Write("Vertex " + i + " -> ");
                    for (int j = 0; j < adjMatrix[i].Count; j++)
                    {
                        if (adjMatrix[i][j] == 1)
                        {
                            Console.Write(j + " ");

                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
