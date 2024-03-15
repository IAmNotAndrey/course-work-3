using ParaPen.ModelViews.Dialogs;
using System;
using System.Windows;

namespace ParaPen.Views;

/// <summary>
/// Логика взаимодействия для InkPenActionDialog.xaml
/// </summary>
public partial class InkPenActionDialog : Window
{
	public InkPenActionDialog()
	{
		InitializeComponent();
		//fixme 
		//((InkPenActionDialogVM)DataContext).CancelCommand = new Action(this.Close);
	}
}
