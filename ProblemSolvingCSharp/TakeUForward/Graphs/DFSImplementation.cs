namespace ProblemSolvingCSharp.TakeUForward.Graphs
{
    [TestClass]
    public class DFSImplementation
    {
        [TestMethod]
        public void GraphDFS_TraversesInExpectedOrder()
        {
            Graph g = new Graph(6);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 3);
            g.AddEdge(2, 4);
            g.AddEdge(3, 5);

            var sw = new StringWriter();
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(sw);

                // Act
                DFS(g, 0);
            }
            finally
            {
                // Restore console
                Console.SetOut(originalOut);
            }

            // Assert
            var outputLines = sw.ToString()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var expected = new[]
            {
                "Visited Node: 0",
                "Visited Node: 1",
                "Visited Node: 3",
                "Visited Node: 5",
                "Visited Node: 2",
                "Visited Node: 4"

            };

            CollectionAssert.AreEqual(expected, outputLines);
        }

        public List<int> DfsOfGraphUtil(int V, Dictionary<int, List<int>> adj)
        {
            List<int> result = new List<int>();
            bool[] visited = new bool[V];
            DfsOfGraphUtil(adj, 0, visited, result);
            return result;
        }

        internal void DfsOfGraphUtil(Dictionary<int, List<int>> adj, int vertex, bool[] visited, List<int> result)
        {
            visited[vertex] = true;
            result.Add(vertex);
            foreach (var neighbor in adj[vertex])
            {
                if (!visited[neighbor])
                {
                    DfsOfGraphUtil(adj, neighbor, visited, result);
                }
            }
        }

        internal void DFS(Graph graph, int startVertex)
        {
            bool[] visited = new bool[graph.VertexCount];
            DFSUtil(graph, startVertex, visited);
        }


        internal void DFSUtil(Graph graph, int vertex, bool[] visited)
        {
            visited[vertex] = true;
            Console.WriteLine("Visited Node: " + vertex);
            foreach (var neighbor in graph.GetNeighbors(vertex))
            {
                if (!visited[neighbor])
                {
                    DFSUtil(graph, neighbor, visited);
                }
            }
        }

        internal void DFSUtil(List<List<int>> adjList, int vertex, bool[] visited)
        {
            visited[vertex] = true;
            Console.WriteLine("Visited Node: " + vertex);
            foreach (var neighbor in adjList[vertex])
            {
                if (!visited[neighbor])
                {
                    DFSUtil(adjList, neighbor, visited);
                }
            }
        }

        internal void FindConnectedComponents(List<List<int>> adjList, int V)
        {
            bool[] visited = new bool[adjList.Count];
            int componentCount = 0;
            for (int i = 0; i < adjList.Count; i++)
            {
                if (!visited[i])
                {
                    componentCount++;
                    DFSUtil(adjList, i, visited);
                }
            }
            Console.WriteLine("Number of connected components: " + componentCount);
        }

        internal void DetectCycleDFS(Graph graph)
        {
            bool[] visited = new bool[graph.VertexCount];
            for (int i = 0; i < graph.VertexCount; i++)
            {
                if (!visited[i])
                {
                    if (DetectCycleDFSUtil(graph, i, visited, -1))
                    {
                        Console.WriteLine("Cycle detected in the graph.");
                        return;
                    }
                }
            }
            Console.WriteLine("No cycle detected in the graph.");
        }

        internal bool DetectCycleDFSUtil(Graph graph, int current, bool[] visited, int parent)
        {
            visited[current] = true;

            foreach (int neighbor in graph.GetNeighbors(current))
            {
                if (!visited[neighbor])
                {
                    if (DetectCycleDFSUtil(graph, neighbor, visited, current))
                        return true;
                }
                else if (neighbor != parent)
                {
                    return true;
                }
            }

            return false;
        }


        internal class Graph
        {
            private List<LinkedList<int>> adjList;
            internal int VertexCount => adjList.Count;
            internal Graph(int vertices)
            {
                adjList = new List<LinkedList<int>>(vertices);
                for (int i = 0; i < vertices; i++)
                {
                    adjList.Add(new LinkedList<int>());
                }
            }

            public void AddEdge(int src, int dest)
            {
                adjList[src].AddLast(dest);
                adjList[dest].AddLast(src);
            }

            public List<int> GetNeighbors(int vertex)
            {
                if (vertex < 0 || vertex >= adjList.Count)
                {
                    throw new ArgumentOutOfRangeException("Vertex out of range ", nameof(vertex));
                }

                return [.. adjList[vertex]];
            }

            public void PrintAdjList()
            {
                for (int i = 0; i < adjList.Count; i++)
                {
                    Console.Write("Vertex " + i + ":");
                    foreach (var neighbor in adjList[i])
                    {
                        Console.Write(" -> " + neighbor);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
