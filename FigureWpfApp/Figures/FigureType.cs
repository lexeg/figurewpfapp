using System.ComponentModel;
using System.Reflection;

namespace FigureWpfApp.Figures
{
    public enum FigureType
    {
        [Description("Квадрат")]
        Square,
        [Description("Треугольник")]
        Triangle,
        [Description("Окружность")]
        Circle
    }

    public static class FigureTypeExtensions
    {
        public static string GetDescription(this FigureType figureType)
        {
            FieldInfo fi = figureType.GetType().GetField(figureType.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : figureType.ToString();
        }
    }
}
