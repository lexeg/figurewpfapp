namespace FigureWpfApp.Figures
{
    public sealed class Square : FigureBase
    {
        private readonly double m_Size;
        public Square(string name, double size) : base(name)
        {
            if (size <= 0) throw new NegativeException("size must be positive");
            m_Size = size;
        }
        public override FigureType Type => FigureType.Square;

        public override double Perimeter => 4 * m_Size;

        public double Size => m_Size;

        public override string Name { get; set; }
    }
}