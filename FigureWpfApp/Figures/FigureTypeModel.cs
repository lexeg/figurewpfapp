namespace FigureWpfApp.Figures
{
    public sealed class FigureTypeModel
    {
        private readonly FigureType m_FigureType;

        public FigureTypeModel(FigureType figureType)
        {
            m_FigureType = figureType;
        }

        public string Name => m_FigureType.GetDescription();

        public FigureType GetFigureType => m_FigureType;
    }
}