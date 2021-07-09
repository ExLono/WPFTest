using System.Windows;

using Test2.ViewModel;

namespace Test2.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
    {
		public MainWindow()
		{
			InitializeComponent();
            DataContext = new MainWindowViewModels();
        }

	}
}
