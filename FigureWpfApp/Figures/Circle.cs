using System;

namespace FigureWpfApp.Figures
{
    public sealed class Circle : FigureBase
    {
        private double m_Diameter;
        public Circle(double diameter)
        {
            if (diameter <= 0) throw new ArgumentException("diameter must be positive");
            m_Diameter = diameter;
        }
        public override FigureType Type => FigureType.Square;

        public override double Perimeter => Math.PI * m_Diameter;

        public double Diameter => m_Diameter;
    }
}