using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FigureWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Action<ControlTemplate> action = new Action<ControlTemplate>(o => FindResource(o));
            Func<string, ControlTemplate> func = new Func<string, ControlTemplate>(o => FindResource(o) as ControlTemplate);
            DataContext = new FiguresViewModel(func);
        }
    }
}
