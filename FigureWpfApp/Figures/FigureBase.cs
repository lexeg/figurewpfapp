namespace FigureWpfApp.Figures
{
    public abstract class FigureBase
    {
        public abstract FigureType Type { get; }
        public abstract double Perimeter { get; }
        public string Name { get { return Type.GetDescription(); } }
        public string TypeName { get { return Type.GetDescription(); } }
    }
}