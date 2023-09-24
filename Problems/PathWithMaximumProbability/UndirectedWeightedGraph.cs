namespace LeetCodeProblems.Problems.PathWithMaximumProbability;

public class UndirectedWeightedGraph
{
    public Dictionary<int, Vertex> Vertices { get; set; }
    public bool[] DiscoveryQueue { get; set; }
    public UndirectedWeightedGraph(int n)
    {
        Vertices = new Dictionary<int, Vertex>();
        DiscoveryQueue = new bool[n];
    }

    public void InsertEdge(int v1, int v2, double weight)
    {
        // if v1 isn't in the graph yet
        if (!Vertices.TryGetValue(v1, out var vertex1))
        {
            vertex1 = new Vertex(v1);
            Vertices.Add(v1, vertex1);
        }

        // if v2 isn't in the graph yet
        if (!Vertices.TryGetValue(v2, out var vertex2))
        {
            vertex2 = new Vertex(v2);
            Vertices.Add(v2, vertex2);
        }

        Vertices[v1].AddNeighbor(vertex2, weight);
        Vertices[v2].AddNeighbor(vertex1, weight);
    }

    /*
     * SPFA algorithm
     */
    public double BestPath(int startNode, int endNode, double[] dp)
    {
        Vertex node;
        Vertex neighbor;
        double weight;

        var prob = 0.0;

        var q = new Queue<int>();

        DiscoverNode(startNode, q);

        while (q.Count > 0)
        {
            node = GetNextVertex(q);

            for (var i = 0; i < node.Neighbors.Count; i++)
            {
                neighbor = node.Neighbors.ElementAt(i).Item1;
                weight = node.Neighbors.ElementAt(i).Item2;

                prob = dp[node.Id] * weight;

                // if we just found a better path to "neighbor" than we knew about previously,
                if (prob > dp[neighbor.Id])
                {
                    dp[neighbor.Id] = prob;

                    DiscoverNode(neighbor.Id, q);
                }
            }
        }

        return dp[endNode];
    }

    public bool DoesVertexExist(int id)
    {
        if (!Vertices.TryGetValue(id, out var v))
        {
            return false;
        }

        return true;
    }

    private Vertex GetNextVertex(Queue<int> q)
    {
        var nodeId = q.Dequeue();
        DiscoveryQueue[nodeId] = false;
        return Vertices[nodeId];
    }

    private void DiscoverNode(int id, Queue<int> q)
    {
        if (!DiscoveryQueue[id])
        {
            q.Enqueue(id);
            DiscoveryQueue[id] = true;
        }
    }
}

public class Vertex
{
    public int Id { get; set; }
    public HashSet<(Vertex, double)> Neighbors { get; set; }

    public Vertex(int id)
    {
        Id = id;
        Neighbors = new HashSet<(Vertex, double)>();
    }

    public void AddNeighbor(Vertex vertex, double weight)
    {
        Neighbors.Add((vertex, weight));
    }
}