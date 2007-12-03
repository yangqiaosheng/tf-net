﻿using System;
using System.Collections.Generic;

namespace Topology.Graph.Predicates
{
    [Serializable]
    public class FilteredVertexAndEdgeListGraph<TVertex, TEdge, TGraph> :
        FilteredVertexListGraph<TVertex, TEdge, TGraph>,
        IVertexAndEdgeListGraph<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
        where TGraph : IVertexAndEdgeListGraph<TVertex, TEdge>
    {
        public FilteredVertexAndEdgeListGraph(
            TGraph baseGraph,
            VertexPredicate<TVertex> vertexPredicate,
            EdgePredicate<TVertex, TEdge> edgePredicate
            )
            :base(baseGraph,vertexPredicate,edgePredicate)
        { }

        public bool IsEdgesEmpty
        {
            get
            {
                return this.EdgeCount == 0;
            }
        }

        public int EdgeCount
        {
            get
            {
                int count = 0;
                foreach (TEdge edge in this.BaseGraph.Edges)
                {
                    if (
                           this.VertexPredicate(edge.Source)
                        && this.VertexPredicate(edge.Target)
                        && this.EdgePredicate(edge))
                        count++;
                }
                return count;
            }
        }

        public IEnumerable<TEdge> Edges
        {
            get
            {
                foreach(TEdge edge in this.BaseGraph.Edges)
                {
                    if (
                           this.VertexPredicate(edge.Source)
                        && this.VertexPredicate(edge.Target)
                        && this.EdgePredicate(edge))
                        yield return edge;
                }
            }
        }

        public bool ContainsEdge(TEdge edge)
        {
            foreach (TEdge e in this.Edges)
                if (Comparison<TEdge>.Equals(edge, e))
                    return true;
            return false;
        }
    }
}
