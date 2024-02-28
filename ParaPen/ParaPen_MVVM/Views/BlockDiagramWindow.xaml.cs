using QuickGraph;
using System.Linq;
using System.Windows;

namespace ParaPen.Views
{
	public partial class BlockDiagramWindow : Window
	{
		// note : возможно, стоит использовать более простой граф, который запрещает создание двусторонних связей
		public BidirectionalGraph<object, IEdge<object>> Graph1 { get; private set; }
		public BlockDiagramWindow()
		{
			CreateGraphToVisualize();
			DataContext = this; // Установка DataContext для привязки в XAML

			InitializeComponent();

		}

		private void CreateGraphToVisualize()
		{
			var g = new BidirectionalGraph<object, IEdge<object>>();

			//add the vertices to the graph
			string[] vertices = new string[12];
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = i.ToString();
				g.AddVertex(vertices[i]);
			}

			//add some edges to the graph
			g.AddEdge(new Edge<object>(vertices[0], vertices[1]));
			g.AddEdge(new Edge<object>(vertices[1], vertices[2]));
			g.AddEdge(new Edge<object>(vertices[2], vertices[3]));
			g.AddEdge(new Edge<object>(vertices[3], vertices[2]));
			g.AddEdge(new Edge<object>(vertices[0], vertices[4]));

			g.AddEdge(new Edge<object>(vertices[5], vertices[6]));
			g.AddEdge(new Edge<object>(vertices[6], vertices[5]));
			g.AddEdge(new Edge<object>(vertices[6], vertices[7]));
			g.AddEdge(new Edge<object>(vertices[7], vertices[8]));
			g.AddEdge(new Edge<object>(vertices[8], vertices[9]));
			g.AddEdge(new Edge<object>(vertices[9], vertices[10]));
			g.AddEdge(new Edge<object>(vertices[10], vertices[11]));
			g.AddEdge(new Edge<object>(vertices[11], vertices[11]));

			Graph1 = g;
		}

		private int _count = 20;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// note : методы как будто делают одно и то же

			// bug : // ломает работу выравнивания при инициализации
			//graphLayout.RecalculateEdgeRouting(); 
			//graphLayout.RecalculateOverlapRemoval();

			//BidirectionalGraph<object, IEdge<object>> g = new();
			string vertice = _count.ToString();
			_count++;
			Graph1.AddVertex(vertice);
			Graph1.AddEdge(new Edge<object>(vertice, Graph1.Vertices.ToList()[0]));
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			graphLayout.RecalculateEdgeRouting();
			graphLayout.RecalculateOverlapRemoval();
		}
	}
}
