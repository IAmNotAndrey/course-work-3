using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ParaPen.Interfaces;

namespace ParaPen;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly IUserViewMover _userViewMover;
	private readonly IInkScaler _inkScaler;
	private readonly InkDrawer _drawer;

	private InkPen _pen1;
	private InkPen _pen2;

	public MainWindow()
	{
		InitializeComponent();

		_userViewMover = new UserViewMover(this);
		_inkScaler = new InkScaler(this, inkCanvas, 1.1);
		_drawer = new(inkCanvas, _userViewMover);

		_pen1 = new(inkCanvas, new DrawingAttributes { Color = Colors.Red, Width = 4, Height = 4 }, _userViewMover);
		InkPenImageDrawer penDrawer1 = new(_pen1, inkImageCanvas);
	}


	// removeme

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		// bug : неправильно отображается рисунок карандаша при движении влево вверх
		_pen1.DrawLine(new System.Windows.Vector(-100, -100));
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		_pen1.Dispose();
		_pen2 = new(inkCanvas, new DrawingAttributes { Color = Colors.Blue, Width = 4, Height = 4 }, _userViewMover);
	}

	// ~removeme
}
