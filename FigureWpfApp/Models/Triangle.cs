using System.Linq;
using FigureWpfApp.Enums;
using FigureWpfApp.Exceptions;

namespace FigureWpfApp.Models
{
    public sealed class Triangle : FigureBase
    {
        private readonly double[] _edges;

        public Triangle(string name, double a, double b, double c) : base(name)
        {
            if (a <= 0 || b <= 0 || c <= 0) throw new NegativeException("edges must be positive");
            _edges = new double[3];
            _edges[0] = a;
            _edges[1] = b;
            _edges[2] = c;
        }

        public override FigureTypes Type => FigureTypes.Triangle;

        public override double Perimeter => _edges.Sum();

        public double[] Edges => _edges;

        public override string Name { get; set; }
    }
}