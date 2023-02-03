using System;

namespace FigureWpfApp.Exceptions
{
    public class NegativeException : Exception
    {
        public NegativeException(string message) : base(message)
        {
        }
    }
}