namespace LeetCodeProblems.Problems.PathWithMaximumProbability;

public class Solution
{
    public double MaxProbability(
        int n,
        int[][] edges,
        double[] succProb,
        int start_node,
        int end_node)
    {
        var graph = BuildGraph(n, edges, succProb);

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


