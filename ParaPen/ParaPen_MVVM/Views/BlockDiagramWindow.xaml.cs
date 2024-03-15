using GraphSharp.Controls;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews;
using QuickGraph;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ParaPen.Views;

public partial class BlockDiagramWindow : Window
{
	public BlockDiagramWindow()
	{
		InitializeComponent();
		//DataContext = new BlockDiagramVM();

	}

	private void graphLayout_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		if (e.Source is EdgeControl edgeControl)
		{
			//removeme
			//var vertexControl = edgeControl.Source;
			////var b = vertexControl.VisualOffset;
			//var transform = vertexControl.TransformToAncestor(graphLayout);
			//var b = transform.Transform(new Point(0, 0));

			//double left = Canvas.GetLeft(vertexControl);
			//double top = Canvas.GetTop(vertexControl);

			var edge = (BlockEdge)edgeControl.Edge;
			((BlockDiagramVM)DataContext).InsertNodeCommand.Execute(edge);

			//InkPenActionNode node = new(STEP_VALUE, PenActions.Draw, Directions.DownRight);
			//((BlockDiagramVM)DataContext).AddActionNodeCommand.Execute(new object[] { node, edge });
		}

		else if (e.Source is VertexControl vertexControl)
		{
			if (vertexControl.Vertex is not CountingLoopNode countingLoopNode)
			{
				return;
			}

			// Получение петли
			var edge = graphLayout.Graph.Edges.SingleOrDefault(e => e.Source == e.Target && e.Source == countingLoopNode);
			if (edge is not null)
			{
				((BlockDiagramVM)DataContext).InsertNodeCommand.Execute(edge);
			}
		}
	}
}
