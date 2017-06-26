using System;

namespace FigureWpfApp.Figures
{
    public sealed class Circle : FigureBase
    {
        private readonly double m_Diameter;
        public Circle(string name, double diameter) : base(name)
        {
            if (diameter <= 0) throw new NegativeException("diameter must be positive");
            m_Diameter = diameter;
        }
        public override FigureType Type => FigureType.Circle;

        public override double Perimeter => Math.PI * m_Diameter;

        public double Diameter => m_Diameter;

        public override string Name { get; set; }
    }
}