//using GraphSharp;
//using GraphSharp.Algorithms.EdgeRouting;
using GraphSharp.Algorithms.Layout;
using QuickGraph;
using System;
using System.Collections.Generic;
using System.Windows;
using GraphSharp.Algorithms.EdgeRouting;
using QuickGraph.Algorithms;

namespace ParaPen._Test;

public class CustomEdgeRoutingAlgorithm<TVertex, TEdge, TGraph> : IEdgeRoutingAlgorithm<TVertex, TEdge, TGraph>
	where TVertex : class
	where TEdge : IEdge<TVertex>
	where TGraph : IBidirectionalGraph<TVertex, TEdge>
{
	private IDictionary<TEdge, Point[]> edgeRoutes;

	public CustomEdgeRoutingAlgorithm()
	{
		edgeRoutes = new Dictionary<TEdge, Point[]>();
	}

	public IDictionary<TEdge, Point[]> EdgeRoutes => throw new NotImplementedException();

	public TGraph VisitedGraph => throw new NotImplementedException();

	public object SyncRoot => throw new NotImplementedException();

	public ComputationState State => throw new NotImplementedException();

	public event EventHandler StateChanged;
	public event EventHandler Started;
	public event EventHandler Finished;
	public event EventHandler Aborted;

	public void Abort()
	{
		throw new NotImplementedException();
	}

	public void Compute()
	{
		throw new NotImplementedException();
	}

	// Остальной код класса
}

