using System.Windows;
using System.Windows.Controls;

namespace FigureWpfApp.Controls
{
    public class SquareControl : Control
    {
        public SquareControl()
        {
            Template = Application.Current.MainWindow.FindResource("SquareTemplate") as ControlTemplate;
        }

        public double Size
        {
            get => (double)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(nameof(Size),
            typeof(double),
            typeof(SquareControl),
            new PropertyMetadata(default(double)));
    }
}