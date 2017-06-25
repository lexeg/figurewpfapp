using System;

namespace FigureWpfApp.Figures
{
    public class NegativeException : Exception
    {
        public NegativeException(string message) : base(message)
        {

        }
    }
}