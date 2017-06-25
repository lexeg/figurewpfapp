using System;
using System.Windows.Input;

namespace FigureWpfApp.Commands
{
    public class BaseAutoEventCommand : ICommand
    {
        private readonly Action<object> m_Action;
        private readonly Func<object, bool> m_Predicate;

        public BaseAutoEventCommand(Action<object> action, Func<object, bool> predicate)
        {
            m_Action = action;
            m_Predicate = predicate;
        }

        public bool CanExecute(object parameter)
        {
            return m_Predicate(parameter);
        }

        public void Execute(object parameter)
        {
            m_Action(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
