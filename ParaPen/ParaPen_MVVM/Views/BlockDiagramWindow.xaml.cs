using GraphSharp.Controls;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews;
using ParaPen.ModelViews.Dialogs;
using System;
using System.Linq;
using System.Windows;
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
		var vm = (BlockDiagramVM)DataContext;

		if (e.Source is EdgeControl edgeControl)
		{
			var edge = (BlockEdge)edgeControl.Edge;

			if (edge.Source is InkConditionNode)
			{
				// Пытаемся получить рёбра, исходящие из `InkPenActionNode`, которые имеют разный `Value`, но сливаются, так как соединяют одинаковые вершины
				// fixme? не проверена работоспосообность
				var inkPenActionNodeOutEdges = vm.BlockDiagram.Edges
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

			vm.InsertNodeCommand.Execute(edge);

			//InkPenActionNode node = new(STEP_VALUE, PenActions.Draw, Directions.DownRight);
			//((BlockDiagramVM)DataContext).AddActionNodeCommand.Execute(new object[] { node, edge });
		}

		else if (e.Source is VertexControl vertexControl)
		{
			// Проверяем, есть ли у вершины петля
			if (!graphLayout.Graph.OutEdges(vertexControl.Vertex).Any(e => ((BlockEdge)e).IsLooped))
			{
				return;
			}

			// Получение петли
			var edge = graphLayout.Graph.Edges.SingleOrDefault(e => e.Source == e.Target && e.Source == vertexControl.Vertex);
			if (edge != null)
			{
				vm.InsertNodeCommand.Execute(edge);
			}
		}
	}

	private void graphLayout_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
	{
		var vm = (BlockDiagramVM)DataContext;

		if (e.Source is VertexControl vertexControl)
		{
			if (vertexControl.Vertex is not TerminalNode)
			{
				vm.DeleteNodeCommand.Execute(vertexControl.Vertex);
			}
		}
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		blockPenContainersFlyout.IsOpen = !blockPenContainersFlyout.IsOpen;
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		tracebackFlyout.IsOpen = !tracebackFlyout.IsOpen;
	}
}
