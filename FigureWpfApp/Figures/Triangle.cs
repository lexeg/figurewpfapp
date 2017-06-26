namespace FigureWpfApp.Figures
{
    public sealed class Triangle : FigureBase
    {
        private readonly double[] m_Edges;

        public Triangle(string name, double a, double b, double c) : base(name)
        {
            if (a <= 0 || b <= 0 || c <= 0) throw new NegativeException("edges must be positive");
            m_Edges = new double[3];
            m_Edges[0] = a;
            m_Edges[1] = b;
            m_Edges[2] = c;
        }

        public override FigureType Type => FigureType.Triangle;

        public override double Perimeter
        {
            get
            {
                var p = 0.0;
                for (int i = 0; i < m_Edges.Length; i++)
                {
                    p += m_Edges[i];
                }
                return p;
            }
        }

        public double[] Edges => m_Edges;

        public override string Name { get; set; }
    }
}