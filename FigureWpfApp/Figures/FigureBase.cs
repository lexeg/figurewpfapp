namespace FigureWpfApp.Figures
{
    public abstract class FigureBase
    {
        protected FigureBase(string name)
        {
            Name = name;
        }

        public abstract FigureType Type { get; }
        public abstract double Perimeter { get; }
        public abstract string Name { get; set; }
        public string TypeName { get { return Type.GetDescription(); } }
    }
}