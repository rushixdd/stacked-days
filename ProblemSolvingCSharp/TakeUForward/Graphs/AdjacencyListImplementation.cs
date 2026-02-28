namespace ProblemSolvingCSharp.TakeUForward.Graphs
{
    [TestClass]
    public class AdjacencyListImplementation
    {
        [TestMethod]
        public void TestAdjacencyList()
        {
            Graph g = new Graph(5);
            g.AddEdge(0, 3);
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(3, 4);
            g.PrintAdjList();
            CollectionAssert.AreEqual(new List<int> { 3, 1 }, g.GetNeighbors(0));
            CollectionAssert.AreEqual(new List<int> { 0, 2 }, g.GetNeighbors(1));
            CollectionAssert.AreEqual(new List<int> { 1 }, g.GetNeighbors(2));
            CollectionAssert.AreEqual(new List<int> { 0, 4 }, g.GetNeighbors(3));
            CollectionAssert.AreEqual(new List<int> { 3 }, g.GetNeighbors(4));
        }


        class Graph
        {
            private List<LinkedList<int>> adjList;

            internal Graph(int vertices) { 
                adjList = new List<LinkedList<int>>(vertices);
                for(int i=0;i<vertices;i++)
                {
                    adjList.Add(new LinkedList<int>());
                }
            }

            public void AddEdge(int src, int dest) {
                adjList[src].AddLast(dest);
                adjList[dest].AddLast(src);
            }

            public List<int> GetNeighbors(int vertex)
            {
                if(vertex < 0 || vertex >= adjList.Count)
                {
                    throw new ArgumentOutOfRangeException("Vertex out of range ", nameof(vertex));
                }

                return [.. adjList[vertex]];
            }

            public void PrintAdjList() {
                for(int i=0;i<adjList.Count;i++)
                {
                    Console.Write("Vertex " + i + ":");
                    foreach(var neighbor in adjList[i])
                    {
                        Console.Write(" -> " + neighbor);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
