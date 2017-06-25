using System;

namespace FigureWpfApp.Figures
{
    public sealed class Square : FigureBase
    {
        private double m_Size;
        public Square(double size)
        {
            if (size <= 0) throw new ArgumentException("size must be positive");
            m_Size = size;
        }
        public override FigureType Type => FigureType.Square;

        public override double Perimeter => 4 * m_Size;

        public double Size => m_Size;
    }
}