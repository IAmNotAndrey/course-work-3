using GraphSharp.Controls;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews;
using ParaPen.ModelViews.Dialogs;
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

			if (edge.Source is InkConditionNode)
			{
				// Пытаемся получить рёбра, исходящие из `InkPenActionNode`, которые имеют разный `Value`, но сливаются, так как соединяют одинаковые вершины
				// fixme? не проверена работоспосообность
				var inkPenActionNodeOutEdges = ((BlockDiagramVM)DataContext).BlockDiagram.Edges
				.Where(e => e.Source == edge.Source
						&& e.Target == edge.Target
				);

				// Если рёбра "наложены" друг на друга, открываем диалог выбора ребра
				if (inkPenActionNodeOutEdges.Count() == 2)
				{
					Window dialog = new EdgeTypeChoosingDialog();
					dialog.ShowDialog();
					bool? selectedEdgeValue = ((EdgeTypeChoosingDialogVM)dialog.DataContext).ChosenEdgeValue;

					if (selectedEdgeValue is null)
					{
						throw new NullReferenceException(nameof(selectedEdgeValue));
					}
					// Записываем одно из выбранных значений рёбер
					edge = inkPenActionNodeOutEdges.Cast<BlockEdge>().Single(e => e.Value == selectedEdgeValue);
				}
			}

			((BlockDiagramVM)DataContext).InsertNodeCommand.Execute(edge);

			//InkPenActionNode node = new(STEP_VALUE, PenActions.Draw, Directions.DownRight);
			//((BlockDiagramVM)DataContext).AddActionNodeCommand.Execute(new object[] { node, edge });
		}

		else if (e.Source is VertexControl vertexControl)
		{
			//if (vertexControl.Vertex is not CountingLoopNode countingLoopNode)
			//{
			//	return;
			//}
			// Проверяем, есть ли у вершины петля
			if (!graphLayout.Graph.OutEdges(vertexControl.Vertex).Any(e => ((BlockEdge)e).IsLooped))
			{
				return;
			}

			// Получение петли
			var edge = graphLayout.Graph.Edges.SingleOrDefault(e => e.Source == e.Target && e.Source == vertexControl.Vertex);
			if (edge is not null)
			{
				((BlockDiagramVM)DataContext).InsertNodeCommand.Execute(edge);
			}
		}
	}
}
