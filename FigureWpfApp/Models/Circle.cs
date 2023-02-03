using System;
using FigureWpfApp.Enums;
using FigureWpfApp.Exceptions;

namespace FigureWpfApp.Models
{
    public sealed class Circle : FigureBase
    {
        private readonly double _diameter;

        public Circle(string name, double diameter) : base(name)
        {
            if (diameter <= 0) throw new NegativeException("diameter must be positive");
            _diameter = diameter;
        }

        public override FigureTypes Type => FigureTypes.Circle;

        public override double Perimeter => Math.PI * _diameter;

        public double Diameter => _diameter;

        public override string Name { get; set; }
    }
}