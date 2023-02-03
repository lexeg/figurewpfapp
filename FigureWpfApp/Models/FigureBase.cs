using FigureWpfApp.Enums;
using FigureWpfApp.Extensions;

namespace FigureWpfApp.Models
{
    public abstract class FigureBase
    {
        protected FigureBase(string name)
        {
            Name = name;
        }

        public abstract FigureTypes Type { get; }
        public abstract double Perimeter { get; }
        public abstract string Name { get; set; }
        public string TypeName => Type.GetDescriptionOrValue();
    }
}