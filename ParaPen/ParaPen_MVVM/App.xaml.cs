using ParaPen.ModelViews;
using ParaPen.Views;
using System.Windows;

namespace ParaPen;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	protected override void OnStartup(StartupEventArgs e)
	{
		MainWindow mainWindow = new();
		mainWindow.Show();
		
		BlockDiagramWindow blockDiagramWindow = new();
		//blockDiagramWindow.blockDiagramUC.DataContext = new BlockDiagramUC_VM(mainWindow.inkCanvas, ((InkCanvasVM)mainWindow.DataContext).UserViewMover);
		blockDiagramWindow.DataContext = new BlockDiagramVM(mainWindow.inkCanvas, ((InkCanvasVM)mainWindow.DataContext).UserViewMover);
		blockDiagramWindow.Show();

		//NodeChoosingDialog d2 = new();
		//d2.ShowDialog();
		//InkPenActionDialog d = new();
		//d.ShowDialog();

		//base.OnStartup(e);
	}
}
