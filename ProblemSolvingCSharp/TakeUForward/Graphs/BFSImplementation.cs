namespace ProblemSolvingCSharp.TakeUForward.Graphs
{
    [TestClass]
    public class BFSImplementation
    {
        [TestMethod]
        public void GraphBFS_TraversesInExpectedOrder()
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
                BFS(g, 0);
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
                "Visited Node: 2",
                "Visited Node: 3",
                "Visited Node: 4",
                "Visited Node: 5"

            };

            CollectionAssert.AreEqual(expected, outputLines);
        }

        [TestMethod]
        public void ShortestPathLengthBetweenTwoNodes_PrintsDistance_WhenPathExists()
        {
            // Arrange
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

                // Act: shortest path from 0 to 5 is 3 (0->1->3->5)
                ShortestPathLengthBetweenTwoNodes(g, 0, 5);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            // Assert
            var output = sw.ToString().Trim();
            Assert.AreEqual("Shortest path length: 3", output);
        }
        public List<int> bfsOfGraph(int V, Dictionary<int, List<int>> adj)
        {
            List<int> result = new List<int>();
            bool[] visited = new bool[V];
            bfsOfGraphUtil(adj, 0, visited, result);
            return result;
        }

        internal void bfsOfGraphUtil(Dictionary<int, List<int>> adj, int vertex, bool[] visited, List<int> result)
        {
            Queue<int> queue = new Queue<int>();
            visited[vertex] = true;
            queue.Enqueue(vertex);
            while(queue.Count > 0)
            {
                int node = queue.Dequeue();
                result.Add(node);
                foreach(var neighbor in adj[node])
                {
                    if(!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        internal void BFS(Graph graph, int startVertex)
        {
            bool[] visited = new bool[graph.VertexCount];
            Queue<int> queue = new Queue<int>();
            visited[startVertex] = true;
            queue.Enqueue(startVertex);
            while(queue.Count > 0)
            {
                int node = queue.Dequeue();
                Console.WriteLine("Visited Node: " + node);
                foreach(var neighbor in graph.GetNeighbors(node))
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        internal void ShortestPathLengthBetweenTwoNodes(Graph graph, int startVertex, int endVertex)
        {
            bool[] visited = new bool[graph.VertexCount];
            Queue<(int node, int distance)> queue = new Queue<(int node, int distance)>();
            visited[startVertex] = true;
            queue.Enqueue((startVertex, 0));
            while (queue.Count > 0)
            {
                var (node, distance) = queue.Dequeue();
                if(node == endVertex)
                {
                    Console.WriteLine("Shortest path length: " + distance);
                    return;
                }
                foreach (var neighbor in graph.GetNeighbors(node))
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue((neighbor, distance + 1));
                    }
                }
            }

            Console.WriteLine("No path exists between the two nodes.");
        }

        public bool IsBipartite(int V, List<int>[] adj)
        {
            int[] colors = new int[V];
            //colors.
            for (int i = 0; i < V; i++)
            {
                if (colors[i] == 0)
                {
                    Queue<int> queue = new Queue<int>();
                    colors[i] = 1;
                    queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        int node = queue.Dequeue();
                        foreach (var neighbor in adj[node])
                        {
                            if (colors[neighbor] == 0)
                            {
                                colors[neighbor] = -colors[node];
                                queue.Enqueue(neighbor);
                            }
                            else if (colors[neighbor] == colors[node])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        internal bool IsBipartite(Graph graph)
        {
            int[] colors = new int[graph.VertexCount];
            for(int i=0;i<graph.VertexCount;i++)
            {
                if(colors[i] == 0)
                {
                    Queue<int> queue = new Queue<int>();
                    colors[i] = 1;
                    queue.Enqueue(i);
                    while(queue.Count > 0)
                    {
                        int node = queue.Dequeue();
                        foreach(var neighbor in graph.GetNeighbors(node))
                        {
                            if(colors[neighbor] == 0)
                            {
                                colors[neighbor] = -colors[node];
                                queue.Enqueue(neighbor);
                            }
                            else if(colors[neighbor] == colors[node])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
