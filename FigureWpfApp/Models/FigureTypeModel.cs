using FigureWpfApp.Enums;
using FigureWpfApp.Extensions;

namespace FigureWpfApp.Models
{
    public sealed class FigureTypeModel
    {
        private readonly FigureTypes _figureType;

        public FigureTypeModel(FigureTypes figureType)
        {
            _figureType = figureType;
        }

        public string Name => _figureType.GetDescriptionOrValue();

        public FigureTypes GetFigureType => _figureType;
    }
}