using ParaPen.Models.CustomGraph;
using ParaPen.ModelViews;
using QuickGraph;
using System;
using System.Windows;

namespace ParaPen.Views;

public partial class BlockDiagramWindow : Window
{
	public BlockDiagramWindow()
	{
		InitializeComponent();
		//DataContext = new BlockDiagramVM();
	}

	private void graphLayout_GiveFeedback(object sender, GiveFeedbackEventArgs e)
	{

    }
}
