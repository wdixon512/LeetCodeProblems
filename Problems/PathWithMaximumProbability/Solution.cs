namespace LeetCodeProblems.Problems.PathWithMaximumProbability;

public class Solution
{
    public double MaxProbability(PathWithMaximumProbabilityProblem p)
        => MaxProbability(p.n, p.edges, p.succProb, p.startNode, p.endNode);


    public double MaxProbability(
        int n,
        int[][] edges,
        double[] succProb,
        int start_node,
        int end_node)
    {
        var graph = BuildGraph(n, edges, succProb);

        if (!graph.DoesVertexExist(start_node) ||
            !graph.DoesVertexExist(end_node))
        {
            return 0;
        }

        return graph.BestPath(start_node, end_node);
    }

    public UndirectedWeightedGraph BuildGraph(int n, int[][] edges, double[] succProb)
    {
        var graph = new UndirectedWeightedGraph(n);

        for (var i = 0; i < edges.Length; i++)
        {
            graph.InsertEdge(edges[i][0], edges[i][1], succProb[i]);
        }

        return graph;
    }
}


