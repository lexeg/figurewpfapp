using FigureWpfApp.Enums;
using FigureWpfApp.Exceptions;

namespace FigureWpfApp.Models
{
    public sealed class Square : FigureBase
    {
        private readonly double _size;

        public Square(string name, double size) : base(name)
        {
            if (size <= 0) throw new NegativeException("size must be positive");
            _size = size;
        }

        public override FigureTypes Type => FigureTypes.Square;

        public override double Perimeter => 4 * _size;

        public double Size => _size;

        public override string Name { get; set; }
    }
}