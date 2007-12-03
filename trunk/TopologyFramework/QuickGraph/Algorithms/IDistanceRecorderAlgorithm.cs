﻿using System;

namespace Topology.Graph.Algorithms
{
    public interface IDistanceRecorderAlgorithm<TVertex,TEdge>
        where TEdge : IEdge<TVertex>
    {
        event VertexEventHandler<TVertex> InitializeVertex;
        event VertexEventHandler<TVertex> DiscoverVertex;
        event EdgeEventHandler<TVertex, TEdge> TreeEdge;
    }
}
