﻿using LeetCodeProblems.Problems.PathWithMaximumProbability;

namespace LeetCodeProblems.Problems;

public partial class Solution
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

        return graph.BestPath(start_node, end_node, InitDpList(start_node, n));
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
    public double[] InitDpList(int startNode, int n)
    {
        var list = new double[n];

        for (var i = 0; i < n; i++)
        {
            list[i] = 0;            
        }

        list[startNode] = 1.0;

        return list;
    }
}


