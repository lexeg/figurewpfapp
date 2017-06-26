using System.Windows;
using System.Windows.Controls;

namespace FigureWpfApp.Controls
{
    public class CircleControl : Control
    {
        public CircleControl()
        {
            Template = Application.Current.MainWindow.FindResource("CircleTemplate") as ControlTemplate;
        }

        public double Diameter
        {
            get { return (double)GetValue(DiameterProperty); }
            set { SetValue(DiameterProperty, value); }
        }

        public static readonly DependencyProperty DiameterProperty =
            DependencyProperty.Register("Diameter", typeof(double), typeof(CircleControl), new PropertyMetadata(default(double)));
    }
}
