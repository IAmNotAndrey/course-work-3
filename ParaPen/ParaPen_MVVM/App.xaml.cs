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
		BlockDiagramWindow blockDiagramWindow = new();
		blockDiagramWindow.Show();

		base.OnStartup(e);
	}
}
