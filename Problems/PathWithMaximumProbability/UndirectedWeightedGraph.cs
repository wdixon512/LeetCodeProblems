namespace LeetCodeProblems.Problems.PathWithMaximumProbability;

public class UndirectedWeightedGraph
{
    public double[,] Matrix { get; set; }
    public Dictionary<int, Vertex> Vertices { get; set; }

    public UndirectedWeightedGraph(int n)
    {
        Matrix = new double[n, n];
        Vertices = new Dictionary<int, Vertex>();
    }

    public void InsertEdge(int v1, int v2, double weight)
    {
        Matrix[v1, v2] = weight;
        Matrix[v2, v1] = weight;

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

        Vertices[v1].AddNeighbor(vertex2);
        Vertices[v2].AddNeighbor(vertex1);
    }


    /*
     * DFS, Use heuristics of local next path's best probability as priority
     * 
     */
    public double BestPath(int startNode, int endNode, HashSet<int>? visited = null)
    {
        if (!DoesVertexExist(startNode, out var vertex) ||
            !DoesVertexExist(endNode, out var endVertex))
        {
            return 0;
        }

        if (startNode == endNode)
        {
            return 1;
        }

        var probability = 0.0;
        var bestProb = 0.0;

        visited = BuildNewVisitedSet(visited);
        visited.Add(startNode);

        foreach (var node in vertex!.UnvisitedNeighbors(visited))
        {
            probability = Matrix[startNode, node.Id] * BestPath(node.Id, endNode, visited);

            if (probability > bestProb)
            {
                bestProb = probability;
            }
        }

        return bestProb;
    }

    public HashSet<int> BuildNewVisitedSet(HashSet<int>? visited)
    {
        if (visited == null)
        {
            return new HashSet<int>();
        }

        return new HashSet<int>(visited);
    }

    public bool DoesVertexExist(int id, out Vertex? vertex)
    {
        vertex = null;

        if (!Vertices.TryGetValue(id, out vertex))
        {
            return false;
        }

        return true;
    }
}


public class Vertex
{
    public int Id { get; set; }
    public HashSet<Vertex> Neighbors { get; set; }

    public Vertex(int id)
    {
        Id = id;
        Neighbors = new HashSet<Vertex>();
    }

    public void AddNeighbor(Vertex vertex)
    {
        Neighbors.Add(vertex);
    }

    public HashSet<Vertex> UnvisitedNeighbors(HashSet<int> visited)
    {
        var res = new HashSet<Vertex>();

        foreach (var neighbor in Neighbors)
        {
            if (!visited.Contains(neighbor.Id))
            {
                res.Add(neighbor);
            }
        }

        return res;
    }
}