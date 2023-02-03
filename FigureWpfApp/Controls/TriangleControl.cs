using System.Windows;
using System.Windows.Controls;

namespace FigureWpfApp.Controls
{
    public class TriangleControl : Control
    {
        public TriangleControl()
        {
            Template = Application.Current.MainWindow.FindResource("TriangleTemplate") as ControlTemplate;
        }

        public double FirstSide
        {
            get => (double)GetValue(FirstSideProperty);
            set => SetValue(FirstSideProperty, value);
        }

        public static readonly DependencyProperty FirstSideProperty = DependencyProperty.Register(nameof(FirstSide),
            typeof(double),
            typeof(TriangleControl),
            new PropertyMetadata(default(double)));

        public double SecondSide
        {
            get => (double)GetValue(SecondSideProperty);
            set => SetValue(SecondSideProperty, value);
        }

        public static readonly DependencyProperty SecondSideProperty = DependencyProperty.Register(nameof(SecondSide),
            typeof(double),
            typeof(TriangleControl),
            new PropertyMetadata(default(double)));

        public double ThirdSide
        {
            get => (double)GetValue(ThirdSideProperty);
            set => SetValue(ThirdSideProperty, value);
        }

        public static readonly DependencyProperty ThirdSideProperty = DependencyProperty.Register(nameof(ThirdSide),
            typeof(double),
            typeof(TriangleControl),
            new PropertyMetadata(default(double)));
    }
}