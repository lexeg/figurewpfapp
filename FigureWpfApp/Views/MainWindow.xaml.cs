using System.Windows;
using FigureWpfApp.ViewModels;

namespace FigureWpfApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FiguresViewModel();
        }
    }
}
